﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

using MetaBrainz.MusicBrainz.Interfaces.Browses;
using MetaBrainz.MusicBrainz.Interfaces.Entities;
using MetaBrainz.MusicBrainz.Objects.Browses;

namespace MetaBrainz.MusicBrainz {

  [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public sealed partial class Query {

    #region Areas

    /// <summary>Returns (the specified subset of) the areas in the given collection.</summary>
    /// <param name="collection">The collection whose contained areas should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArea> BrowseAreas(ICollection collection, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      return new BrowseAreas(this, Query.BuildExtraText(inc, $"collection={collection.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the areas in the given collection.</summary>
    /// <param name="mbid">The MBID for the collection whose contained areas should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArea> BrowseCollectionAreas(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseAreas(this, Query.BuildExtraText(inc, $"collection={mbid:D}"), limit, offset).Next();
    }

    #endregion

    #region Artists

    /// <summary>Returns (the specified subset of) the artists associated with the given area.</summary>
    /// <param name="mbid">The MBID for the area whose artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseAreaArtists(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"area={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given area.</summary>
    /// <param name="area">The area whose artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseArtists(IArea area, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (area == null) throw new ArgumentNullException(nameof(area));
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"area={area.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the artists in the given collection.</summary>
    /// <param name="collection">The collection whose contained artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseArtists(ICollection collection, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"collection={collection.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given recording.</summary>
    /// <param name="recording">The recording whose artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseArtists(IRecording recording, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (recording == null) throw new ArgumentNullException(nameof(recording));
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"recording={recording.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given release.</summary>
    /// <param name="release">The release whose artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseArtists(IRelease release, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (release == null) throw new ArgumentNullException(nameof(release));
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"release={release.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given release group.</summary>
    /// <param name="releaseGroup">The release group whose artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseArtists(IReleaseGroup releaseGroup, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (releaseGroup == null) throw new ArgumentNullException(nameof(releaseGroup));
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"release-group={releaseGroup.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given work.</summary>
    /// <param name="work">The work whose artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseArtists(IWork work, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (work == null) throw new ArgumentNullException(nameof(work));
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"work={work.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the artists in the given collection.</summary>
    /// <param name="mbid">The MBID for the collection whose contained artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseCollectionArtists(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"collection={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the artists associated with the given recording.</summary>
    /// <param name="mbid">The MBID for the recording whose artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseRecordingArtists(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"recording={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the artists associated with the given release.</summary>
    /// <param name="mbid">The MBID for the release whose artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseReleaseArtists(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"release={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the artists associated with the given release group.</summary>
    /// <param name="mbid">The MBID for the release group whose artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseReleaseGroupArtists(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"release-group={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the artists associated with the given work.</summary>
    /// <param name="mbid">The MBID for the work whose artists should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IArtist> BrowseWorkArtists(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseArtists(this, Query.BuildExtraText(inc, $"work={mbid:D}"), limit, offset).Next();
    }

    #endregion

    #region Collections

    /// <summary>Returns (the specified subset of) the collections that include the given area.</summary>
    /// <param name="mbid">The MBID for the area whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseAreaCollections(Guid mbid, int? limit = null, int? offset = null) {
      return new BrowseCollections(this, $"?area={mbid:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given artist.</summary>
    /// <param name="mbid">The MBID for the artist whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseArtistCollections(Guid mbid, int? limit = null, int? offset = null) {
      return new BrowseCollections(this, $"?artist={mbid:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given area.</summary>
    /// <param name="area">The area whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseCollections(IArea area, int? limit = null, int? offset = null) {
      if (area == null) throw new ArgumentNullException(nameof(area));
      return new BrowseCollections(this, $"?area={area.MbId:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given artist.</summary>
    /// <param name="artist">The artist whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseCollections(IArtist artist, int? limit = null, int? offset = null) {
      if (artist == null) throw new ArgumentNullException(nameof(artist));
      return new BrowseCollections(this, $"?artist={artist.MbId:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given event.</summary>
    /// <param name="event">The event whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseCollections(IEvent @event, int? limit = null, int? offset = null) {
      if (@event == null) throw new ArgumentNullException(nameof(@event));
      return new BrowseCollections(this, $"?event={@event.MbId:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given instrument.</summary>
    /// <param name="instrument">The instrument whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseCollections(IInstrument instrument, int? limit = null, int? offset = null) {
      if (instrument == null) throw new ArgumentNullException(nameof(instrument));
      return new BrowseCollections(this, $"?instrument={instrument.MbId:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given label.</summary>
    /// <param name="label">The label whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseCollections(ILabel label, int? limit = null, int? offset = null) {
      if (label == null) throw new ArgumentNullException(nameof(label));
      return new BrowseCollections(this, $"?label={label.MbId:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given place.</summary>
    /// <param name="place">The place whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseCollections(IPlace place, int? limit = null, int? offset = null) {
      if (place == null) throw new ArgumentNullException(nameof(place));
      return new BrowseCollections(this, $"?place={place.MbId:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given recording.</summary>
    /// <param name="recording">The recording whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseCollections(IRecording recording, int? limit = null, int? offset = null) {
      if (recording == null) throw new ArgumentNullException(nameof(recording));
      return new BrowseCollections(this, $"?recording={recording.MbId:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given release.</summary>
    /// <param name="release">The release whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseCollections(IRelease release, int? limit = null, int? offset = null) {
      if (release == null) throw new ArgumentNullException(nameof(release));
      return new BrowseCollections(this, $"?release={release.MbId:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given release group.</summary>
    /// <param name="releaseGroup">The release group whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseCollections(IReleaseGroup releaseGroup, int? limit = null, int? offset = null) {
      if (releaseGroup == null) throw new ArgumentNullException(nameof(releaseGroup));
      return new BrowseCollections(this, $"?release-group={releaseGroup.MbId:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given series.</summary>
    /// <param name="series">The series whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseCollections(ISeries series, int? limit = null, int? offset = null) {
      if (series == null) throw new ArgumentNullException(nameof(series));
      return new BrowseCollections(this, $"?series={series.MbId:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given work.</summary>
    /// <param name="work">The work whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseCollections(IWork work, int? limit = null, int? offset = null) {
      if (work == null) throw new ArgumentNullException(nameof(work));
      return new BrowseCollections(this, $"?work={work.MbId:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections of the given editor.</summary>
    /// <param name="editor">The editor whose collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseEditorCollections(string editor, int? limit = null, int? offset = null) {
      if (editor == null) throw new ArgumentNullException(nameof(editor));
      return new BrowseCollections(this, $"?editor={editor}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given event.</summary>
    /// <param name="mbid">The MBID for the event whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseEventCollections(Guid mbid, int? limit = null, int? offset = null) {
      return new BrowseCollections(this, $"?event={mbid:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given instrument.</summary>
    /// <param name="mbid">The MBID for the instrument whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseInstrumentCollections(Guid mbid, int? limit = null, int? offset = null) {
      return new BrowseCollections(this, $"?instrument={mbid:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given label.</summary>
    /// <param name="mbid">The MBID for the label whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseLabelCollections(Guid mbid, int? limit = null, int? offset = null) {
      return new BrowseCollections(this, $"?label={mbid:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given place.</summary>
    /// <param name="mbid">The MBID for the place whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowsePlaceCollections(Guid mbid, int? limit = null, int? offset = null) {
      return new BrowseCollections(this, $"?place={mbid:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given recording.</summary>
    /// <param name="mbid">The MBID for the recording whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseRecordingCollections(Guid mbid, int? limit = null, int? offset = null) {
      return new BrowseCollections(this, $"?recording={mbid:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given release.</summary>
    /// <param name="mbid">The MBID for the release whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseReleaseCollections(Guid mbid, int? limit = null, int? offset = null) {
      return new BrowseCollections(this, $"?release={mbid:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given release group.</summary>
    /// <param name="mbid">The MBID for the release group whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseReleaseGroupCollections(Guid mbid, int? limit = null, int? offset = null) {
      return new BrowseCollections(this, $"?release-group={mbid:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given series.</summary>
    /// <param name="mbid">The MBID for the series whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseSeriesCollections(Guid mbid, int? limit = null, int? offset = null) {
      return new BrowseCollections(this, $"?series={mbid:D}", limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the collections that include the given work.</summary>
    /// <param name="mbid">The MBID for the work whose containing collections should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ICollection> BrowseWorkCollections(Guid mbid, int? limit = null, int? offset = null) {
      return new BrowseCollections(this, $"?work={mbid:D}", limit, offset).Next();
    }

    #endregion

    #region Events

    /// <summary>Returns (the specified subset of) the events associated with the given area.</summary>
    /// <param name="mbid">The MBID for the area whose events should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IEvent> BrowseAreaEvents(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseEvents(this, Query.BuildExtraText(inc, $"area={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the events associated with the given artist.</summary>
    /// <param name="mbid">The MBID for the artist whose events should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IEvent> BrowseArtistEvents(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseEvents(this, Query.BuildExtraText(inc, $"artist={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the events in the given collection.</summary>
    /// <param name="mbid">The MBID for the collection whose contained events should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IEvent> BrowseCollectionEvents(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseEvents(this, Query.BuildExtraText(inc, $"collection={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the events associated with the given area.</summary>
    /// <param name="area">The area whose events should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IEvent> BrowseEvents(IArea area, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (area == null) throw new ArgumentNullException(nameof(area));
      return new BrowseEvents(this, Query.BuildExtraText(inc, $"area={area.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the events associated with the given artist.</summary>
    /// <param name="artist">The artist whose events should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IEvent> BrowseEvents(IArtist artist, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (artist == null) throw new ArgumentNullException(nameof(artist));
      return new BrowseEvents(this, Query.BuildExtraText(inc, $"artist={artist.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the events in the given collection.</summary>
    /// <param name="collection">The collection whose contained events should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IEvent> BrowseEvents(ICollection collection, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      return new BrowseEvents(this, Query.BuildExtraText(inc, $"collection={collection.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the events associated with the given place.</summary>
    /// <param name="place">The place whose events should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IEvent> BrowseEvents(IPlace place, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (place == null) throw new ArgumentNullException(nameof(place));
      return new BrowseEvents(this, Query.BuildExtraText(inc, $"place={place.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the events associated with the given place.</summary>
    /// <param name="mbid">The MBID for the place whose events should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IEvent> BrowsePlaceEvents(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseEvents(this, Query.BuildExtraText(inc, $"place={mbid:D}"), limit, offset).Next();
    }

    #endregion

    #region Instruments

    /// <summary>Returns (the specified subset of) the instruments in the given collection.</summary>
    /// <param name="collection">The collection whose contained instruments should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IInstrument> BrowseInstruments(ICollection collection, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      return new BrowseInstruments(this, Query.BuildExtraText(inc, $"collection={collection.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the instruments in the given collection.</summary>
    /// <param name="mbid">The MBID for the collection whose contained instruments should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IInstrument> BrowseCollectionInstruments(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseInstruments(this, Query.BuildExtraText(inc, $"collection={mbid:D}"), limit, offset).Next();
    }

    #endregion

    #region Labels

    /// <summary>Returns (the specified subset of) the labels associated with the given area.</summary>
    /// <param name="mbid">The MBID for the area whose labels should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ILabel> BrowseAreaLabels(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseLabels(this, Query.BuildExtraText(inc, $"area={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the labels in the given collection.</summary>
    /// <param name="mbid">The MBID for the collection whose contained labels should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ILabel> BrowseCollectionLabels(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseLabels(this, Query.BuildExtraText(inc, $"collection={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the labels associated with the given release.</summary>
    /// <param name="mbid">The MBID for the release whose labels should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ILabel> BrowseReleaseLabels(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseLabels(this, Query.BuildExtraText(inc, $"release={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the labels associated with the given area.</summary>
    /// <param name="area">The area whose labels should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ILabel> BrowseLabels(IArea area, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (area == null) throw new ArgumentNullException(nameof(area));
      return new BrowseLabels(this, Query.BuildExtraText(inc, $"area={area.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the labels in the given collection.</summary>
    /// <param name="collection">The collection whose contained labels should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ILabel> BrowseLabels(ICollection collection, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      return new BrowseLabels(this, Query.BuildExtraText(inc, $"collection={collection.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the labels associated with the given release.</summary>
    /// <param name="release">The release whose labels should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ILabel> BrowseLabels(IRelease release, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (release == null) throw new ArgumentNullException(nameof(release));
      return new BrowseLabels(this, Query.BuildExtraText(inc, $"release={release.MbId:D}"), limit, offset).Next();
    }

    #endregion

    #region Places

    /// <summary>Returns (the specified subset of) the places associated with the given area.</summary>
    /// <param name="mbid">The MBID for the area whose places should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IPlace> BrowseAreaPlaces(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowsePlaces(this, Query.BuildExtraText(inc, $"area={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the places in the given collection.</summary>
    /// <param name="mbid">The MBID for the collection whose contained places should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IPlace> BrowseCollectionPlaces(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowsePlaces(this, Query.BuildExtraText(inc, $"collection={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the places associated with the given area.</summary>
    /// <param name="area">The area whose places should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IPlace> BrowsePlaces(IArea area, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (area == null) throw new ArgumentNullException(nameof(area));
      return new BrowsePlaces(this, Query.BuildExtraText(inc, $"area={area.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the places in the given collection.</summary>
    /// <param name="collection">The collection whose contained places should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IPlace> BrowsePlaces(ICollection collection, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      return new BrowsePlaces(this, Query.BuildExtraText(inc, $"collection={collection.MbId:D}"), limit, offset).Next();
    }

    #endregion

    #region Recordings

    /// <summary>Returns (the specified subset of) the recordings associated with the given artist.</summary>
    /// <param name="mbid">The MBID for the artist whose recordings should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRecording> BrowseArtistRecordings(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseRecordings(this, Query.BuildExtraText(inc, $"artist={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the recordings in the given collection.</summary>
    /// <param name="mbid">The MBID for the collection whose contained recordings should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRecording> BrowseCollectionRecordings(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseRecordings(this, Query.BuildExtraText(inc, $"collection={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the recordings associated with the given release.</summary>
    /// <param name="mbid">The MBID for the release whose recordings should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRecording> BrowseReleaseRecordings(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseRecordings(this, Query.BuildExtraText(inc, $"release={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the recordings associated with the given artist.</summary>
    /// <param name="artist">The artist whose recordings should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRecording> BrowseRecordings(IArtist artist, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (artist == null) throw new ArgumentNullException(nameof(artist));
      return new BrowseRecordings(this, Query.BuildExtraText(inc, $"artist={artist.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the recordings in the given collection.</summary>
    /// <param name="collection">The collection whose contained recordings should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRecording> BrowseRecordings(ICollection collection, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      return new BrowseRecordings(this, Query.BuildExtraText(inc, $"collection={collection.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the recordings associated with the given release.</summary>
    /// <param name="release">The release whose recordings should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRecording> BrowseRecordings(IRelease release, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (release == null) throw new ArgumentNullException(nameof(release));
      return new BrowseRecordings(this, Query.BuildExtraText(inc, $"release={release.MbId:D}"), limit, offset).Next();
    }

    #endregion

    #region Releases

    /// <summary>Returns (the specified subset of) the releases associated with the given area.</summary>
    /// <param name="mbid">The MBID for the area whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseAreaReleases(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"area={mbid:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given artist.</summary>
    /// <param name="mbid">The MBID for the artist whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseArtistReleases(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"artist={mbid:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases in the given collection.</summary>
    /// <param name="mbid">The MBID for the collection whose contained releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseCollectionReleases(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"collection={mbid:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given label.</summary>
    /// <param name="mbid">The MBID for the label whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseLabelReleases(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"label={mbid:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given recording.</summary>
    /// <param name="mbid">The MBID for the recording whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseRecordingReleases(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"recording={mbid:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given release group.</summary>
    /// <param name="mbid">The MBID for the release group whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseReleaseGroupReleases(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"release-group={mbid:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given area.</summary>
    /// <param name="area">The area whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseReleases(IArea area, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      if (area == null) throw new ArgumentNullException(nameof(area));
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"area={area.MbId:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given artist.</summary>
    /// <param name="artist">The artist whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseReleases(IArtist artist, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      if (artist == null) throw new ArgumentNullException(nameof(artist));
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"artist={artist.MbId:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases in the given collection.</summary>
    /// <param name="collection">The collection whose contained releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseReleases(ICollection collection, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"collection={collection.MbId:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given label.</summary>
    /// <param name="label">The label whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseReleases(ILabel label, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      if (label == null) throw new ArgumentNullException(nameof(label));
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"label={label.MbId:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given recording.</summary>
    /// <param name="recording">The recording whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseReleases(IRecording recording, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      if (recording == null) throw new ArgumentNullException(nameof(recording));
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"recording={recording.MbId:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given release group.</summary>
    /// <param name="releaseGroup">The release group whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseReleases(IReleaseGroup releaseGroup, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      if (releaseGroup == null) throw new ArgumentNullException(nameof(releaseGroup));
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"release-group={releaseGroup.MbId:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given track.</summary>
    /// <param name="track">The track whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseReleases(ITrack track, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      if (track == null) throw new ArgumentNullException(nameof(track));
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"track={track.MbId:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases associated with the given track.</summary>
    /// <param name="mbid">The MBID for the track whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseTrackReleases(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"track={mbid:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases that include the given artist in a track-level artist credit only.</summary>
    /// <param name="mbid">The MBID for the artist whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseTrackArtistReleases(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"track_artist={mbid:D}", type, status), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the releases that include the given artist in a track-level artist credit only.</summary>
    /// <param name="artist">The artist whose releases should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <param name="status">The release status to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IRelease> BrowseTrackArtistReleases(IArtist artist, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null, ReleaseStatus? status = null) {
      if (artist == null) throw new ArgumentNullException(nameof(artist));
      return new BrowseReleases(this, Query.BuildExtraText(inc, $"track_artist={artist.MbId:D}", type, status), limit, offset).Next();
    }

    #endregion

    #region Release Groups

    /// <summary>Returns (the specified subset of) the release groups associated with the given artist.</summary>
    /// <param name="mbid">The MBID for the artist whose release groups should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IReleaseGroup> BrowseArtistReleaseGroups(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null) {
      return new BrowseReleaseGroups(this, Query.BuildExtraText(inc, $"artist={mbid:D}", type), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the release groups in the given collection.</summary>
    /// <param name="mbid">The MBID for the collection whose contained release groups should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IReleaseGroup> BrowseCollectionReleaseGroups(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null) {
      return new BrowseReleaseGroups(this, Query.BuildExtraText(inc, $"collection={mbid:D}", type), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the release groups associated with the given release.</summary>
    /// <param name="mbid">The MBID for the release whose release groups should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    /// <remarks>
    ///   Currently a release can only be part of a single release group, so assuming <paramref name="mbid"/> is valid, this should always return exactly one result.
    /// </remarks>
    public IBrowseResults<IReleaseGroup> BrowseReleaseReleaseGroups(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null) {
      return new BrowseReleaseGroups(this, Query.BuildExtraText(inc, $"release={mbid:D}", type), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the release groups associated with the given artist.</summary>
    /// <param name="artist">The artist whose release groups should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IReleaseGroup> BrowseReleaseGroups(IArtist artist, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null) {
      if (artist == null) throw new ArgumentNullException(nameof(artist));
      return new BrowseReleaseGroups(this, Query.BuildExtraText(inc, $"artist={artist.MbId:D}", type), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the release groups in the given collection.</summary>
    /// <param name="collection">The collection whose contained release groups should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IReleaseGroup> BrowseReleaseGroups(ICollection collection, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      return new BrowseReleaseGroups(this, Query.BuildExtraText(inc, $"collection={collection.MbId:D}", type), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the release groups associated with the given release.</summary>
    /// <param name="release">The release whose release groups should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <param name="type">The release type to filter on (if any).</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    /// <remarks>Currently a release can only be part of a single release group, so this should always return exactly one result.</remarks>
    public IBrowseResults<IReleaseGroup> BrowseReleaseGroups(IRelease release, int? limit = null, int? offset = null, Include inc = Include.None, ReleaseType? type = null) {
      if (release == null) throw new ArgumentNullException(nameof(release));
      return new BrowseReleaseGroups(this, Query.BuildExtraText(inc, $"release={release.MbId:D}", type), limit, offset).Next();
    }

    #endregion

    #region Series

    /// <summary>Returns (the specified subset of) the series in the given collection.</summary>
    /// <param name="collection">The collection whose contained series should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ISeries> BrowseSeries(ICollection collection, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      return new BrowseSeries(this, Query.BuildExtraText(inc, $"collection={collection.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the series in the given collection.</summary>
    /// <param name="mbid">The MBID for the collection whose contained series should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<ISeries> BrowseCollectionSeries(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseSeries(this, Query.BuildExtraText(inc, $"collection={mbid:D}"), limit, offset).Next();
    }

    #endregion

    #region Works

    /// <summary>Returns (the specified subset of) the works associated with the given artist.</summary>
    /// <param name="mbid">The MBID for the artist whose works should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IWork> BrowseArtistWorks(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseWorks(this, Query.BuildExtraText(inc, $"artist={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the works in the given collection.</summary>
    /// <param name="mbid">The MBID for the collection whose contained works should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IWork> BrowseCollectionWorks(Guid mbid, int? limit = null, int? offset = null, Include inc = Include.None) {
      return new BrowseWorks(this, Query.BuildExtraText(inc, $"collection={mbid:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the works associated with the given artist.</summary>
    /// <param name="artist">The artist whose works should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IWork> BrowseWorks(IArtist artist, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (artist == null) throw new ArgumentNullException(nameof(artist));
      return new BrowseWorks(this, Query.BuildExtraText(inc, $"artist={artist.MbId:D}"), limit, offset).Next();
    }

    /// <summary>Returns (the specified subset of) the works in the given collection.</summary>
    /// <param name="collection">The collection whose contained works should be retrieved.</param>
    /// <param name="limit">The maximum number of results to return (1-100; default is 25).</param>
    /// <param name="offset">The offset at which to start (i.e. the number of results to skip).</param>
    /// <param name="inc">Additional information to include in the result.</param>
    /// <returns>The browse request, including the initial results.</returns>
    /// <exception cref="QueryException">When the web service reports an error.</exception>
    /// <exception cref="WebException">When something goes wrong with the web request.</exception>
    public IBrowseResults<IWork> BrowseWorks(ICollection collection, int? limit = null, int? offset = null, Include inc = Include.None) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      return new BrowseWorks(this, Query.BuildExtraText(inc, $"collection={collection.MbId:D}"), limit, offset).Next();
    }

    #endregion

  }

}
