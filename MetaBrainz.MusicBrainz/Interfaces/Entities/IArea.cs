﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MetaBrainz.MusicBrainz.Interfaces.Entities {

  #if NETFX_GE_4_5
  using StringList = IReadOnlyList<string>;
  #else
  using StringList = IEnumerable<string>;
  #endif

  /// <summary>A MusicBrainz area.</summary>
  [SuppressMessage("ReSharper", "RedundantExtendsListEntry")]
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public interface IArea : IEntity, IAnnotatedEntity, INamedEntity, IRelatableEntity, ITaggableEntity, ITypedEntity {

    /// <summary>The ISO 3166-1 codes associated with this area, if any.</summary>
    StringList Iso31661Codes { get; }

    /// <summary>The ISO 3166-2 codes associated with this area, if any.</summary>
    StringList Iso31662Codes { get; }

    /// <summary>The ISO 3166-3 codes associated with this area, if any.</summary>
    StringList Iso31663Codes { get; }

    /// <summary>The area's lifespan.</summary>
    ILifeSpan LifeSpan { get; }

  }

}
