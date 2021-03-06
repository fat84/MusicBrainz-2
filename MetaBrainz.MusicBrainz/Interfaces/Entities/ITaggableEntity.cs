﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MetaBrainz.MusicBrainz.Interfaces.Entities {

  #if NETFX_GE_4_5
  using TagList     = IReadOnlyList<ITag>;
  using UserTagList = IReadOnlyList<IUserTag>;
  #else
  using TagList     = IEnumerable<ITag>;
  using UserTagList = IEnumerable<IUserTag>;
  #endif

  /// <summary>A entity that can have tags applied to it.</summary>
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public interface ITaggableEntity : IEntity {

    /// <summary>The tags associated with this entity.</summary>
    TagList Tags { get; }

    /// <summary>The tags set on this entity by the authenticated user.</summary>
    UserTagList UserTags { get; }

  }

}
