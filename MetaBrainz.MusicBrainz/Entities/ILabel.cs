﻿using System.Collections.Generic;

namespace MetaBrainz.MusicBrainz.Entities {

  public interface ILabel : IMbEntity, IAnnotatedEntity, INamedEntity, IRatedEntity, IRelatableEntity, ITaggedEntity, ITypedEntity {

    IArea Area { get; }

    string Country { get; }

    IEnumerable<string> Ipis { get; }

    IEnumerable<string> Isnis { get; }

    int? LabelCode { get; }

    ILifeSpan LifeSpan { get; }

    IEnumerable<IRelease> Releases { get; }

  }

}
