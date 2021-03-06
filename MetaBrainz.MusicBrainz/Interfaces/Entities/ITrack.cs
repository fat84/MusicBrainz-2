﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MetaBrainz.MusicBrainz.Interfaces.Entities {

  #if NETFX_GE_4_5
  using NameCreditList = IReadOnlyList<INameCredit>;
  #else
  using NameCreditList = IEnumerable<INameCredit>;
  #endif

  /// <summary>A track on a medium.</summary>
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
  public interface ITrack {

    /// <summary>The MBID for the track.</summary>
    Guid MbId { get; }

    /// <summary>The artist credit for the track.</summary>
    NameCreditList ArtistCredit { get; }

    /// <summary>The length of the track, in milliseconds.</summary>
    int? Length { get; }

    /// <summary>The number of the track on its medium.</summary>
    string Number { get; }

    /// <summary>The recording associated with the track.</summary>
    IRecording Recording { get; }

    /// <summary>The track title.</summary>
    string Title { get; }

  }

}
