﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace MetaBrainz.MusicBrainz.DiscId.Platforms {

  internal sealed class Linux : Unix {

    public Linux() : base(CdDeviceFeature.ReadTableOfContents | CdDeviceFeature.ReadMediaCatalogNumber | CdDeviceFeature.ReadTrackIsrc) { }

    public override string DefaultDevice => "/dev/cdrom";

    public override string GetDeviceByIndex(int n) {
      if (n < 0)
        return null;
      using (var info = System.IO.File.OpenText("/proc/sys/dev/cdrom/info")) {
        string line;
        while ((line = info.ReadLine()) != null) {
          if (line.StartsWith("drive name:")) {
            var devices = line.Substring(11).Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (n >= devices.Length)
              return null;
            Array.Reverse(devices);
            return string.Concat("/dev/", devices[n]);
          }
        }
      }
      return null;
    }

    public override TableOfContents ReadTableOfContents(string device, CdDeviceFeature features) {
      if (device == null) {
        // Prefer the generic name
        using (var fd = NativeApi.OpenDevice(device = this.DefaultDevice)) {
          if (fd.IsInvalid) // But if that does not exist, try the first specific one
            device = this.GetDeviceByIndex(0);
        }
        if (device == null) // But we do need a device at this point
          throw new NotSupportedException("No cd-rom device found.");
      }
      using (var fd = NativeApi.OpenDevice(device)) {
        if (fd.IsInvalid)
          throw new IOException($"Failed to open '{device}'.", new UnixException());
        byte first = 0;
        byte last  = 0;
        TableOfContents.RawTrack[] tracks = null;
        { // Read the TOC itself
          MMC3.TOCDescriptor rawtoc;
          NativeApi.GetTableOfContents(fd, out rawtoc);
          first = rawtoc.FirstTrack;
          last = rawtoc.LastTrack;
          tracks = new TableOfContents.RawTrack[last + 1];
          var i = 0;
          for (var trackno = rawtoc.FirstTrack; trackno <= rawtoc.LastTrack; ++trackno, ++i) { // Add the regular tracks.
            if (rawtoc.Tracks[i].TrackNumber != trackno)
              throw new InvalidDataException($"Internal logic error; first track is {rawtoc.FirstTrack}, but entry at index {i} claims to be track {rawtoc.Tracks[i].TrackNumber} instead of {trackno}");
            var isrc = ((features & CdDeviceFeature.ReadTrackIsrc) != 0) ? NativeApi.GetTrackIsrc(fd, trackno) : null;
            tracks[trackno] = new TableOfContents.RawTrack(rawtoc.Tracks[i].Address, rawtoc.Tracks[i].ControlAndADR.Control, isrc);
          }
          // Next entry should be the leadout (track number 0xAA)
          if (rawtoc.Tracks[i].TrackNumber != 0xAA)
            throw new InvalidDataException($"Internal logic error; track data ends with a record that reports track number {rawtoc.Tracks[i].TrackNumber} instead of 0xAA (lead-out)");
          tracks[0] = new TableOfContents.RawTrack(rawtoc.Tracks[i].Address, rawtoc.Tracks[i].ControlAndADR.Control, null);
        }
        // TODO: If requested, try getting CD-TEXT data.
        var mcn = ((features & CdDeviceFeature.ReadMediaCatalogNumber) != 0) ? NativeApi.GetMediaCatalogNumber(fd) : null;
        return new TableOfContents(device, first, last, tracks, mcn);
      }
    }

    #region Native API

    // ReSharper disable InconsistentNaming
    // ReSharper disable UnusedMember.Local

    private static class NativeApi {

      #region Constants

      // in milliseconds; timeout better shouldn't happen for scsi commands -> device is reset
      private const uint DefaultSCSIRequestTimeOut = 30000;

      [Flags]
      private enum FileOpenFlags : uint {
        // Access Modes
        ReadOnly              = 0x0000, // O_RDONLY
        WriteOnly             = 0x0001, // O_WRONLY
        ReadWrite             = 0x0002, // O_RDWR
        AccessMode            = 0x0003, // O_ACCMODE
        // Open-Time Flags
        Create                = 0x0040, // O_CREAT
        Exclusive             = 0x0080, // O_EXCL
        CreateNew             = Create | Exclusive,
        NonBlocking           = 0x0800, // O_NONBLOCK
        NoControllingTerminal = 0x0100, // O_NOCTTY
        Truncate              = 0x0200, // O_TRUNC
        // Operation Modes
        Append                = 0x0400, // O_APPEND
      }

      private enum IOCTL : int {
        // Generic SCSI command (uses standard SCSI MMC structures)
        SG_IO              = 0x2285,
      }

      [Flags]
      private enum SCSIFlags : uint {
        SG_FLAG_DIRECT_IO   = 1,       // default is indirect IO
        SG_FLAG_LUN_INHIBIT = 2,       // default is to put device's lun into the 2nd byte of SCSI command
        SG_FLAG_NO_DXFER    = 0x10000, // no transfer of kernel buffers to/from user space (debug indirect IO)
      }

      [Flags]
      private enum SCSIInfoStatus : uint {
        SG_INFO_OK    = 0x00, // no sense, host nor driver "noise"
        SG_INFO_CHECK = 0x01, // something abnormal happened
      }

      [Flags]
      private enum SCSIInfoIOMode : uint {
        SG_INFO_INDIRECT_IO = 0x00, // data xfer via kernel buffers (or no xfer)
        SG_INFO_DIRECT_IO   = 0x02, // direct IO requested and performed
        SG_INFO_MIXED_IO    = 0x04, // part direct, part indirect IO
      }

      private enum SCSITransferDirection : int {
        SG_DXFER_NONE        = -1, // e.g. a SCSI Test Unit Ready command
        SG_DXFER_TO_DEV      = -2, // e.g. a SCSI WRITE command
        SG_DXFER_FROM_DEV    = -3, // e.g. a SCSI READ command
        SG_DXFER_TO_FROM_DEV = -4, // like SG_DXFER_FROM_DEV, but during indirect IO the user buffer is copied into the kernel buffers before the transfer
      }

      #endregion

      #region Structures

      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      private struct SCSIRequest {
        public int                   interface_id;
        public SCSITransferDirection dxfer_direction;
        public byte                  cmd_len;
        public byte                  mx_sb_len;
        public ushort                iovec_count;
        public uint                  dxfer_len;
        public IntPtr                dxferp;
        public IntPtr                cmdp;
        public IntPtr                sbp;
        public uint                  timeout;
        public SCSIFlags             flags;
        public int                   pack_id;
        public IntPtr                usr_ptr;
        public byte                  status;
        public byte                  masked_status;
        public byte                  msg_status;
        public byte                  sb_len_wr;
        public ushort                host_status;
        public ushort                driver_status;
        public int                   resid;
        public uint                  duration;
        public uint                  info;

        public SCSIInfoStatus Status => (SCSIInfoStatus) (info & 0x1);
        public SCSIInfoIOMode IOMode => (SCSIInfoIOMode) (info & 0x6);
      }

      #endregion

      #region Public Methods

      public static string GetMediaCatalogNumber(SafeUnixHandle fd) {
        MMC3.SubChannelMediaCatalogNumber mcn;
        var cmd = MMC3.CDB.ReadSubChannel.MediaCatalogNumber();
        if (NativeApi.SendSCSIRequest(fd, ref cmd, out mcn) == -1)
          throw new IOException("Failed to retrieve media catalog number.", new UnixException());
        mcn.FixUp();
        return mcn.Status.IsValid ? Encoding.ASCII.GetString(mcn.MCN) : string.Empty;
      }

      public static void GetTableOfContents(SafeUnixHandle fd, out MMC3.TOCDescriptor rawtoc) {
        var msf = false;
        var cmd = MMC3.CDB.ReadTocPmaAtip.TOC(msf);
        if (NativeApi.SendSCSIRequest(fd, ref cmd, out rawtoc) == -1)
          throw new IOException("Failed to retrieve table of contents.", new UnixException());
        rawtoc.FixUp(msf);
      }

      public static string GetTrackIsrc(SafeUnixHandle fd, byte track) {
        MMC3.SubChannelISRC isrc;
        var cmd = MMC3.CDB.ReadSubChannel.ISRC(track);
        if (NativeApi.SendSCSIRequest(fd, ref cmd, out isrc) == -1)
          throw new IOException($"Failed to retrieve ISRC for track {track}.", new UnixException());
        isrc.FixUp();
        return isrc.Status.IsValid ? Encoding.ASCII.GetString(isrc.ISRC) : string.Empty;
      }

      public static Unix.SafeUnixHandle OpenDevice(string name) => Unix.Open(name, (uint) (FileOpenFlags.ReadOnly | FileOpenFlags.NonBlocking), 0);

      #endregion

      #region Private Methods

      private static int SendSCSIRequest<TCommand, TData>(SafeUnixHandle fd, ref TCommand cmd, out TData data) where TCommand : struct where TData : struct {
        SCSIRequest req = new SCSIRequest {
          interface_id    = 'S',
          dxfer_direction = SCSITransferDirection.SG_DXFER_FROM_DEV,
          timeout         = NativeApi.DefaultSCSIRequestTimeOut,
        };
        {
          var cmdlen = Marshal.SizeOf(typeof(TCommand));
          if (cmdlen > 16)
            throw new InvalidOperationException("A SCSI command must not exceed 16 bytes in size.");
          req.cmd_len = (byte) cmdlen;
        }
        req.mx_sb_len = 16;
        req.dxfer_len = (uint) Marshal.SizeOf(typeof(TData));
        data = default(TData);
        var bytes = Marshal.AllocHGlobal(new IntPtr(req.cmd_len + req.mx_sb_len + req.dxfer_len));
        try {
          req.cmdp   = bytes;
          req.sbp    = req.cmdp + req.cmd_len;
          req.dxferp = req.sbp  + req.mx_sb_len;
          Marshal.StructureToPtr(cmd, req.cmdp, false);
          try {
            var rc = NativeApi.SendSCSIRequest(fd, IOCTL.SG_IO, ref req);
            data = (TData) Marshal.PtrToStructure(req.dxferp, typeof(TData));
            return rc;
          }
          finally {
            Marshal.DestroyStructure(req.cmdp, typeof(TCommand));
          }
        }
        finally {
          Marshal.FreeHGlobal(bytes);
        }
      }

      [DllImport("libc", EntryPoint = "ioctl", SetLastError = true)]
      private static extern int SendSCSIRequest(SafeUnixHandle fd, IOCTL command, ref SCSIRequest request);

    }

    #endregion

  }

  #endregion

}