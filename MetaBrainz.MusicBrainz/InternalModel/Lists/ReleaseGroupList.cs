﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using MetaBrainz.MusicBrainz.Resources;

#pragma warning disable 649

namespace MetaBrainz.MusicBrainz.InternalModel.Lists {

  [Serializable]
  public sealed class ReleaseGroupList : ItemList, IResourceList<IReleaseGroup> {

    [XmlElement("release-group")] public ReleaseGroup[] Items;

    #region IResourceList<IReleaseGroup>

    uint? IResourceList<IReleaseGroup>.Count => this.ListCount;

    uint? IResourceList<IReleaseGroup>.Offset => this.ListOffset;

    IEnumerable<IReleaseGroup> IResourceList<IReleaseGroup>.Items => this.Items;

    #endregion

  }

}
