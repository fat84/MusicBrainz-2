﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MetaBrainz.MusicBrainz.Entities {

  #if NETFX_LT_4_5
  using NameCreditList = IEnumerable<INameCredit>;
  using StringList     = IEnumerable<string>;
  using ReleaseList    = IEnumerable<IRelease>;
  #else
  using NameCreditList = IReadOnlyList<INameCredit>;
  using StringList     = IReadOnlyList<string>;
  using ReleaseList    = IReadOnlyList<IRelease>;
  #endif

  /// <summary>A MusicBrainz recording.</summary>
  [SuppressMessage("ReSharper", "RedundantExtendsListEntry")]
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
  public interface IRecording : IEntity, IAnnotatedEntity, IRatableEntity, IRelatableEntity, ITaggableEntity, ITitledEntity {

    /// <summary>The artist credit for the recording.</summary>
    NameCreditList ArtistCredit { get; }

    /// <summary>The ISRC (International Standard Recording Code) values associated with this release.</summary>
    StringList Isrcs { get; }

    /// <summary>The length of the recording, in milliseconds.</summary>
    int? Length { get; }

    /// <summary>The releases that include the recording.</summary>
    ReleaseList Releases { get; }

    /// <summary>Flag indicating whether or not this recording includes visual content.</summary>
    bool Video { get; }

  }

}
