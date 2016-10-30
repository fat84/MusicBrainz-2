﻿using System;
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json;

namespace MetaBrainz.MusicBrainz.Entities.Objects {

  internal sealed class Collection : ICollection {

    public EntityType EntityType => EntityType.Collection;

    public string Id => this.MbId.ToString("D");

    public Guid MbId => this._json.id;

    public string Editor => this._json.editor;

    public EntityType ContentType {
      get {
        if (this._entityType.HasValue)
          return this._entityType.Value;
        switch (this._json.entity_type) {
          case "area":          return (this._entityType = EntityType.Area        ).Value;
          case "artist":        return (this._entityType = EntityType.Artist      ).Value;
          case "collection":    return (this._entityType = EntityType.Collection  ).Value; // not currently possible
          case "event":         return (this._entityType = EntityType.Event       ).Value;
          case "instrument":    return (this._entityType = EntityType.Instrument  ).Value;
          case "label":         return (this._entityType = EntityType.Label       ).Value;
          case "place":         return (this._entityType = EntityType.Place       ).Value;
          case "recording":     return (this._entityType = EntityType.Recording   ).Value;
          case "release":       return (this._entityType = EntityType.Release     ).Value;
          case "release_group": return (this._entityType = EntityType.ReleaseGroup).Value;
          case "series":        return (this._entityType = EntityType.Series      ).Value;
          case "url":           return (this._entityType = EntityType.Url         ).Value; // not currently possible
          case "work":          return (this._entityType = EntityType.Work        ).Value;
          default:              return (this._entityType = EntityType.Unknown     ).Value;
        }
      }
    }

    private EntityType? _entityType;

    public string ContentTypeText => this._json.entity_type;

    public int ItemCount =>   this._json.area_count
                            + this._json.artist_count
                            + this._json.event_count
                            + this._json.instrument_count
                            + this._json.label_count
                            + this._json.place_count
                            + this._json.recording_count
                            + this._json.release_count
                            + this._json.release_group_count
                            + this._json.series_count
                            + this._json.work_count;

    public string Name => this._json.name;

    public string Type => this._json.type;

    public Guid? TypeId => this._json.type_id;

    #region JSON-Based Construction

    internal Collection(JSON json) {
      this._json = json;
    }

    private readonly JSON _json;

    #pragma warning disable 649

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal sealed class JSON {
      [JsonProperty("area-count")] public int area_count;
      [JsonProperty("artist-count")] public int artist_count;
      [JsonProperty] public string editor;
      [JsonProperty("entity-type")] public string entity_type;
      [JsonProperty("event-count")] public int event_count;
      [JsonProperty(Required = Required.Always)] public Guid id;
      [JsonProperty("instrument-count")] public int instrument_count;
      [JsonProperty("label-count")] public int label_count;
      [JsonProperty] public string name;
      [JsonProperty("place-count")] public int place_count;
      [JsonProperty("recording-count")] public int recording_count;
      [JsonProperty("release-count")] public int release_count;
      [JsonProperty("release-group-count")] public int release_group_count;
      [JsonProperty("series-count")] public int series_count;
      [JsonProperty] public string type;
      [JsonProperty("type-id")] public Guid? type_id;
      [JsonProperty("work-count")] public int work_count;
    }

    #endregion

  }

}