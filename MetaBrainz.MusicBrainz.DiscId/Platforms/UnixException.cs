﻿using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MetaBrainz.MusicBrainz.DiscId.Platforms {

  /// <summary>Exception thrown for a Unix-related error (based on the &quot;errno&quot; value).</summary>
  [Serializable]
  public class UnixException : ExternalException {

    /// <summary>Initializes a new instance of the <see cref="UnixException"/> class, for the most recent error reported by a Unix system routine.</summary>
    public UnixException() : this(Marshal.GetLastWin32Error()) { }

    /// <summary>Initializes a new instance of the <see cref="UnixException"/> class, for the specified error code.</summary>
    public UnixException(int errno) : base(UnixException.GetErrorText(errno), errno) { }

    private static string GetErrorText(int errno) {
      UnixException.ThreadLock.EnterWriteLock();
      try {
        return Marshal.PtrToStringAnsi(UnixException.StrError(errno));
      }
      catch (DllNotFoundException)        { }
      catch (EntryPointNotFoundException) { }
      finally {
        UnixException.ThreadLock.ExitWriteLock();
      }
      return $"[errno {errno}]";
    }

    // strerror() is not threadsafe, and strerror_r() is not portable, so use strerror() plus a lock to help with the threadsafety issue.
    private static readonly ReaderWriterLockSlim ThreadLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

    [DllImport("libc", EntryPoint = "strerror", SetLastError = true)]
    private static extern IntPtr StrError(int error);

  }

}
