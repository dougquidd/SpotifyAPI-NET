using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web
{
    public interface ISpotifyWebAPI
    {
        /// <summary>
        ///     The type of the <see cref="AccessToken"/>
        /// </summary>
        string TokenType { get; set; }

        /// <summary>
        ///     A valid token issued by spotify. Used only when <see cref="UseAuth"/> is true
        /// </summary>
        string AccessToken { get; set; }

        /// <summary>
        ///     If true, an authorization header based on <see cref="TokenType"/> and <see cref="AccessToken"/> will be used
        /// </summary>
        bool UseAuth { get; set; }

        /// <summary>
        ///     A custom WebClient, used for Unit-Testing
        /// </summary>
        IClient WebClient { get; set; }

        /// <summary>
        ///     Specifies after how many miliseconds should a failed request be retried.
        /// </summary>
        int RetryAfter { get; set; }

        /// <summary>
        ///     Should a failed request (specified by <see cref="RetryErrorCodes"/> be automatically retried or not.
        /// </summary>
        bool UseAutoRetry { get; set; }

        /// <summary>
        ///     Maximum number of tries for one failed request.
        /// </summary>
        int RetryTimes { get; set; }

        /// <summary>
        ///     Whether a failure of type "Too Many Requests" should use up one of the allocated retry attempts.
        /// </summary>
        bool TooManyRequestsConsumesARetry { get; set; }

        /// <summary>
        ///     Error codes that will trigger auto-retry if <see cref="UseAutoRetry"/> is enabled.
        /// </summary>
        IEnumerable<int> RetryErrorCodes { get; set; }

        /// <summary>
        ///     Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.
        /// </summary>
        /// <param name="q">The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues.</param>
        /// <param name="type">A list of item types to search across.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first result to return. Default: 0</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code or the string from_token.</param>
        /// <returns></returns>
        SearchItem SearchItems(string q, SearchType type, int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string asynchronously.
        /// </summary>
        /// <param name="q">The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues.</param>
        /// <param name="type">A list of item types to search across.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first result to return. Default: 0</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code or the string from_token.</param>
        /// <returns></returns>
        Task<SearchItem> SearchItemsAsync(string q, SearchType type, int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.
        /// </summary>
        /// <param name="q">The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues. (properly escaped)</param>
        /// <param name="type">A list of item types to search across.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first result to return. Default: 0</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code or the string from_token.</param>
        /// <returns></returns>
        SearchItem SearchItemsEscaped(string q, SearchType type, int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string asynchronously.
        /// </summary>
        /// <param name="q">The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues. (properly escaped)</param>
        /// <param name="type">A list of item types to search across.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first result to return. Default: 0</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code or the string from_token.</param>
        /// <returns></returns>
        Task<SearchItem> SearchItemsEscapedAsync(string q, SearchType type, int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Get Spotify catalog information about an album’s tracks. Optional parameters can be used to limit the number of
        ///     tracks returned.
        /// </summary>
        /// <param name="id">The Spotify ID for the album.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first track to return. Default: 0 (the first object).</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        Paging<SimpleTrack> GetAlbumTracks(string id, int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Get Spotify catalog information about an album’s tracks asynchronously. Optional parameters can be used to limit the number of
        ///     tracks returned.
        /// </summary>
        /// <param name="id">The Spotify ID for the album.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first track to return. Default: 0 (the first object).</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        Task<Paging<SimpleTrack>> GetAlbumTracksAsync(string id, int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Get Spotify catalog information for a single album.
        /// </summary>
        /// <param name="id">The Spotify ID for the album.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        FullAlbum GetAlbum(string id, string market = "");

        /// <summary>
        ///     Get Spotify catalog information for a single album asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the album.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        Task<FullAlbum> GetAlbumAsync(string id, string market = "");

        /// <summary>
        ///     Get Spotify catalog information for multiple albums identified by their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        SeveralAlbums GetSeveralAlbums(List<string> ids, string market = "");

        /// <summary>
        ///     Get Spotify catalog information for multiple albums identified by their Spotify IDs asynchrously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        Task<SeveralAlbums> GetSeveralAlbumsAsync(List<string> ids, string market = "");

        /// <summary>
        ///     Get Spotify catalog information for a single artist identified by their unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        FullArtist GetArtist(string id);

        /// <summary>
        ///     Get Spotify catalog information for a single artist identified by their unique Spotify ID asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        Task<FullArtist> GetArtistAsync(string id);

        /// <summary>
        ///     Get Spotify catalog information about artists similar to a given artist. Similarity is based on analysis of the
        ///     Spotify community’s listening history.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        SeveralArtists GetRelatedArtists(string id);

        /// <summary>
        ///     Get Spotify catalog information about artists similar to a given artist asynchronously. Similarity is based on analysis of the
        ///     Spotify community’s listening history.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        Task<SeveralArtists> GetRelatedArtistsAsync(string id);

        /// <summary>
        ///     Get Spotify catalog information about an artist’s top tracks by country.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="country">The country: an ISO 3166-1 alpha-2 country code.</param>
        /// <returns></returns>
        SeveralTracks GetArtistsTopTracks(string id, string country);

        /// <summary>
        ///     Get Spotify catalog information about an artist’s top tracks by country asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="country">The country: an ISO 3166-1 alpha-2 country code.</param>
        /// <returns></returns>
        Task<SeveralTracks> GetArtistsTopTracksAsync(string id, string country);

        /// <summary>
        ///     Get Spotify catalog information about an artist’s albums. Optional parameters can be specified in the query string
        ///     to filter and sort the response.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="type">
        ///     A list of keywords that will be used to filter the response. If not supplied, all album types will
        ///     be returned
        /// </param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first album to return. Default: 0</param>
        /// <param name="market">
        ///     An ISO 3166-1 alpha-2 country code. Supply this parameter to limit the response to one particular
        ///     geographical market
        /// </param>
        /// <returns></returns>
        Paging<SimpleAlbum> GetArtistsAlbums(string id, AlbumType type = AlbumType.All, int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Get Spotify catalog information about an artist’s albums asynchronously. Optional parameters can be specified in the query string
        ///     to filter and sort the response.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="type">
        ///     A list of keywords that will be used to filter the response. If not supplied, all album types will
        ///     be returned
        /// </param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first album to return. Default: 0</param>
        /// <param name="market">
        ///     An ISO 3166-1 alpha-2 country code. Supply this parameter to limit the response to one particular
        ///     geographical market
        /// </param>
        /// <returns></returns>
        Task<Paging<SimpleAlbum>> GetArtistsAlbumsAsync(string id, AlbumType type = AlbumType.All, int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Get Spotify catalog information for several artists based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the artists. Maximum: 50 IDs.</param>
        /// <returns></returns>
        SeveralArtists GetSeveralArtists(List<string> ids);

        /// <summary>
        ///     Get Spotify catalog information for several artists based on their Spotify IDs asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the artists. Maximum: 50 IDs.</param>
        /// <returns></returns>
        Task<SeveralArtists> GetSeveralArtistsAsync(List<string> ids);

        /// <summary>
        ///     Get a list of Spotify featured playlists (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="locale">
        ///     The desired language, consisting of a lowercase ISO 639 language code and an uppercase ISO 3166-1
        ///     alpha-2 country code, joined by an underscore.
        /// </param>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="timestamp">A timestamp in ISO 8601 format</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <remarks>AUTH NEEDED</remarks>
        FeaturedPlaylists GetFeaturedPlaylists(string locale = "", string country = "", DateTime timestamp = default(DateTime), int limit = 20, int offset = 0);

        /// <summary>
        ///     Get a list of Spotify featured playlists asynchronously (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="locale">
        ///     The desired language, consisting of a lowercase ISO 639 language code and an uppercase ISO 3166-1
        ///     alpha-2 country code, joined by an underscore.
        /// </param>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="timestamp">A timestamp in ISO 8601 format</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <remarks>AUTH NEEDED</remarks>
        Task<FeaturedPlaylists> GetFeaturedPlaylistsAsync(string locale = "", string country = "", DateTime timestamp = default(DateTime), int limit = 20, int offset = 0);

        /// <summary>
        ///     Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        NewAlbumReleases GetNewAlbumReleases(string country = "", int limit = 20, int offset = 0);

        /// <summary>
        ///     Get a list of new album releases featured in Spotify asynchronously (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<NewAlbumReleases> GetNewAlbumReleasesAsync(string country = "", int limit = 20, int offset = 0);

        /// <summary>
        ///     Get a list of categories used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">
        ///     A country: an ISO 3166-1 alpha-2 country code. Provide this parameter if you want to narrow the
        ///     list of returned categories to those relevant to a particular country
        /// </param>
        /// <param name="locale">
        ///     The desired language, consisting of an ISO 639 language code and an ISO 3166-1 alpha-2 country
        ///     code, joined by an underscore
        /// </param>
        /// <param name="limit">The maximum number of categories to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="offset">The index of the first item to return. Default: 0 (the first object).</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        CategoryList GetCategories(string country = "", string locale = "", int limit = 20, int offset = 0);

        /// <summary>
        ///     Get a list of categories used to tag items in Spotify asynchronously (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">
        ///     A country: an ISO 3166-1 alpha-2 country code. Provide this parameter if you want to narrow the
        ///     list of returned categories to those relevant to a particular country
        /// </param>
        /// <param name="locale">
        ///     The desired language, consisting of an ISO 639 language code and an ISO 3166-1 alpha-2 country
        ///     code, joined by an underscore
        /// </param>
        /// <param name="limit">The maximum number of categories to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="offset">The index of the first item to return. Default: 0 (the first object).</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<CategoryList> GetCategoriesAsync(string country = "", string locale = "", int limit = 20, int offset = 0);

        /// <summary>
        ///     Get a single category used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">
        ///     A country: an ISO 3166-1 alpha-2 country code. Provide this parameter to ensure that the category
        ///     exists for a particular country.
        /// </param>
        /// <param name="locale">
        ///     The desired language, consisting of an ISO 639 language code and an ISO 3166-1 alpha-2 country
        ///     code, joined by an underscore
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Category GetCategory(string categoryId, string country = "", string locale = "");

        /// <summary>
        ///     Get a single category used to tag items in Spotify asynchronously (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">
        ///     A country: an ISO 3166-1 alpha-2 country code. Provide this parameter to ensure that the category
        ///     exists for a particular country.
        /// </param>
        /// <param name="locale">
        ///     The desired language, consisting of an ISO 639 language code and an ISO 3166-1 alpha-2 country
        ///     code, joined by an underscore
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<Category> GetCategoryAsync(string categoryId, string country = "", string locale = "");

        /// <summary>
        ///     Get a list of Spotify playlists tagged with a particular category.
        /// </summary>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        CategoryPlaylist GetCategoryPlaylists(string categoryId, string country = "", int limit = 20, int offset = 0);

        /// <summary>
        ///     Get a list of Spotify playlists tagged with a particular category asynchronously.
        /// </summary>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<CategoryPlaylist> GetCategoryPlaylistsAsync(string categoryId, string country = "", int limit = 20, int offset = 0);

        /// <summary>
        ///     Create a playlist-style listening experience based on seed artists, tracks and genres.
        /// </summary>
        /// <param name="artistSeed">A comma separated list of Spotify IDs for seed artists.
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="genreSeed">A comma separated list of any genres in the set of available genre seeds.
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="trackSeed">A comma separated list of Spotify IDs for a seed track.
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="target">Tracks with the attribute values nearest to the target values will be preferred.</param>
        /// <param name="min">For each tunable track attribute, a hard floor on the selected track attribute’s value can be provided</param>
        /// <param name="max">For each tunable track attribute, a hard ceiling on the selected track attribute’s value can be provided</param>
        /// <param name="limit">The target size of the list of recommended tracks. Default: 20. Minimum: 1. Maximum: 100.
        /// For seeds with unusually small pools or when highly restrictive filtering is applied, it may be impossible to generate the requested number of recommended tracks.
        /// </param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.
        /// Because min_*, max_* and target_* are applied to pools before relinking, the generated results may not precisely match the filters applied.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Recommendations GetRecommendations(List<string> artistSeed = null, List<string> genreSeed = null, List<string> trackSeed = null,
            TuneableTrack target = null, TuneableTrack min = null, TuneableTrack max = null, int limit = 20, string market = "");

        /// <summary>
        ///     Create a playlist-style listening experience based on seed artists, tracks and genres asynchronously.
        /// </summary>
        /// <param name="artistSeed">A comma separated list of Spotify IDs for seed artists.
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="genreSeed">A comma separated list of any genres in the set of available genre seeds.
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="trackSeed">A comma separated list of Spotify IDs for a seed track.
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="target">Tracks with the attribute values nearest to the target values will be preferred.</param>
        /// <param name="min">For each tunable track attribute, a hard floor on the selected track attribute’s value can be provided</param>
        /// <param name="max">For each tunable track attribute, a hard ceiling on the selected track attribute’s value can be provided</param>
        /// <param name="limit">The target size of the list of recommended tracks. Default: 20. Minimum: 1. Maximum: 100.
        /// For seeds with unusually small pools or when highly restrictive filtering is applied, it may be impossible to generate the requested number of recommended tracks.
        /// </param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.
        /// Because min_*, max_* and target_* are applied to pools before relinking, the generated results may not precisely match the filters applied.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<Recommendations> GetRecommendationsAsync(List<string> artistSeed = null, List<string> genreSeed = null, List<string> trackSeed = null,
            TuneableTrack target = null, TuneableTrack min = null, TuneableTrack max = null, int limit = 20, string market = "");

        /// <summary>
        ///     Retrieve a list of available genres seed parameter values for recommendations.
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        RecommendationSeedGenres GetRecommendationSeedsGenres();

        /// <summary>
        ///     Retrieve a list of available genres seed parameter values for recommendations asynchronously.
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<RecommendationSeedGenres> GetRecommendationSeedsGenresAsync();

        /// <summary>
        ///     Get the current user’s followed artists.
        /// </summary>
        /// <param name="followType">The ID type: currently only artist is supported. </param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="after">The last artist ID retrieved from the previous request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        FollowedArtists GetFollowedArtists(FollowType followType, int limit = 20, string after = "");

        /// <summary>
        ///     Get the current user’s followed artists asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: currently only artist is supported. </param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="after">The last artist ID retrieved from the previous request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<FollowedArtists> GetFollowedArtistsAsync(FollowType followType, int limit = 20, string after = "");

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse Follow(FollowType followType, List<string> ids);

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> FollowAsync(FollowType followType, List<string> ids);

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse Follow(FollowType followType, string id);

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> FollowAsync(FollowType followType, string id);

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse Unfollow(FollowType followType, List<string> ids);

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> UnfollowAsync(FollowType followType, List<string> ids);

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse Unfollow(FollowType followType, string id);

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> UnfollowAsync(FollowType followType, string id);

        /// <summary>
        ///     Check to see if the current user is following one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs to check</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ListResponse<bool> IsFollowing(FollowType followType, List<string> ids);

        /// <summary>
        ///     Check to see if the current user is following one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs to check</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ListResponse<bool>> IsFollowingAsync(FollowType followType, List<string> ids);

        /// <summary>
        ///     Check to see if the current user is following one artist or another Spotify user.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ListResponse<bool> IsFollowing(FollowType followType, string id);

        /// <summary>
        ///     Check to see if the current user is following one artist or another Spotify user asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ListResponse<bool>> IsFollowingAsync(FollowType followType, string id);

        /// <summary>
        ///     Add the current user as a follower of a playlist.
        /// </summary>
        /// <param name="playlistId">
        ///     The Spotify ID of the playlist. Any playlist can be followed, regardless of its public/private
        ///     status, as long as you know its playlist ID.
        /// </param>
        /// <param name="showPublic">
        ///     If true the playlist will be included in user's public playlists, if false it will remain
        ///     private.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse FollowPlaylist(string ownerId, string playlistId, bool showPublic = true);

        /// <summary>
        ///     Add the current user as a follower of a playlist asynchronously.
        /// </summary>
        /// <param name="playlistId">
        ///     The Spotify ID of the playlist. Any playlist can be followed, regardless of its public/private
        ///     status, as long as you know its playlist ID.
        /// </param>
        /// <param name="showPublic">
        ///     If true the playlist will be included in user's public playlists, if false it will remain
        ///     private.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> FollowPlaylistAsync(string playlistId, bool showPublic = true);

        /// <summary>
        ///     Remove the current user as a follower of a playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID of the playlist that is to be no longer followed.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse UnfollowPlaylist(string playlistId);

        /// <summary>
        ///     Remove the current user as a follower of a playlist asynchronously.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist that is to be no longer followed.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> UnfollowPlaylistAsync(string playlistId);

        /// <summary>
        ///     Check to see if one or more Spotify users are following a specified playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID of the playlist.</param>
        /// <param name="ids">A list of Spotify User IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ListResponse<bool> IsFollowingPlaylist(string playlistId, List<string> ids);

        /// <summary>
        ///     Check to see if one or more Spotify users are following a specified playlist asynchronously.
        /// </summary>
        /// <param name="playlistId">The Spotify ID of the playlist.</param>
        /// <param name="ids">A list of Spotify User IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ListResponse<bool>> IsFollowingPlaylistAsync(string playlistId, List<string> ids);

        /// <summary>
        ///     Check to see if one or more Spotify users are following a specified playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID of the playlist.</param>
        /// <param name="id">A Spotify User ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ListResponse<bool> IsFollowingPlaylist(string playlistId, string id);

        /// <summary>
        ///     Check to see if one or more Spotify users are following a specified playlist asynchronously.
        /// </summary>
        /// <param name="playlistId">The Spotify ID of the playlist.</param>
        /// <param name="id">A Spotify User ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ListResponse<bool>> IsFollowingPlaylistAsync(string playlistId, string id);

        /// <summary>
        ///     Save one or more tracks to the current user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse SaveTracks(List<string> ids);

        /// <summary>
        ///     Save one or more tracks to the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> SaveTracksAsync(List<string> ids);

        /// <summary>
        ///     Save one track to the current user’s “Your Music” library.
        /// </summary>
        /// <param name="id">A Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse SaveTrack(string id);

        /// <summary>
        ///     Save one track to the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="id">A Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> SaveTrackAsync(string id);

        /// <summary>
        ///     Get a list of the songs saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Paging<SavedTrack> GetSavedTracks(int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Get a list of the songs saved in the current Spotify user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<Paging<SavedTrack>> GetSavedTracksAsync(int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Remove one or more tracks from the current user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse RemoveSavedTracks(List<string> ids);

        /// <summary>
        ///     Remove one or more tracks from the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> RemoveSavedTracksAsync(List<string> ids);

        /// <summary>
        ///     Check if one or more tracks is already saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ListResponse<bool> CheckSavedTracks(List<string> ids);

        /// <summary>
        ///     Check if one or more tracks is already saved in the current Spotify user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ListResponse<bool>> CheckSavedTracksAsync(List<string> ids);

        /// <summary>
        ///     Save one or more albums to the current user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse SaveAlbums(List<string> ids);

        /// <summary>
        ///     Save one or more albums to the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> SaveAlbumsAsync(List<string> ids);

        /// <summary>
        ///     Save one album to the current user’s “Your Music” library.
        /// </summary>
        /// <param name="id">A Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse SaveAlbum(string id);

        /// <summary>
        ///     Save one album to the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="id">A Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> SaveAlbumAsync(string id);

        /// <summary>
        ///     Get a list of the albums saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Paging<SavedAlbum> GetSavedAlbums(int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Get a list of the albums saved in the current Spotify user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<Paging<SavedAlbum>> GetSavedAlbumsAsync(int limit = 20, int offset = 0, string market = "");

        /// <summary>
        ///     Remove one or more albums from the current user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse RemoveSavedAlbums(List<string> ids);

        /// <summary>
        ///     Remove one or more albums from the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> RemoveSavedAlbumsAsync(List<string> ids);

        /// <summary>
        ///     Check if one or more albums is already saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ListResponse<bool> CheckSavedAlbums(List<string> ids);

        /// <summary>
        ///     Check if one or more albums is already saved in the current Spotify user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ListResponse<bool>> CheckSavedAlbumsAsync(List<string> ids);

        /// <summary>
        ///     Get the current user’s top tracks based on calculated affinity.
        /// </summary>
        /// <param name="timeRange">Over what time frame the affinities are computed.
        /// Valid values: long_term (calculated from several years of data and including all new data as it becomes available),
        /// medium_term (approximately last 6 months), short_term (approximately last 4 weeks). </param>
        /// <param name="limit">The number of entities to return. Default: 20. Minimum: 1. Maximum: 50</param>
        /// <param name="offest">The index of the first entity to return. Default: 0 (i.e., the first track). Use with limit to get the next set of entities.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Paging<FullTrack> GetUsersTopTracks(TimeRangeType timeRange = TimeRangeType.MediumTerm, int limit = 20, int offest = 0);

        /// <summary>
        ///     Get the current user’s top tracks based on calculated affinity asynchronously.
        /// </summary>
        /// <param name="timeRange">Over what time frame the affinities are computed.
        /// Valid values: long_term (calculated from several years of data and including all new data as it becomes available),
        /// medium_term (approximately last 6 months), short_term (approximately last 4 weeks). </param>
        /// <param name="limit">The number of entities to return. Default: 20. Minimum: 1. Maximum: 50</param>
        /// <param name="offest">The index of the first entity to return. Default: 0 (i.e., the first track). Use with limit to get the next set of entities.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<Paging<FullTrack>> GetUsersTopTracksAsync(TimeRangeType timeRange = TimeRangeType.MediumTerm, int limit = 20, int offest = 0);

        /// <summary>
        ///     Get the current user’s top artists based on calculated affinity.
        /// </summary>
        /// <param name="timeRange">Over what time frame the affinities are computed.
        /// Valid values: long_term (calculated from several years of data and including all new data as it becomes available),
        /// medium_term (approximately last 6 months), short_term (approximately last 4 weeks). </param>
        /// <param name="limit">The number of entities to return. Default: 20. Minimum: 1. Maximum: 50</param>
        /// <param name="offest">The index of the first entity to return. Default: 0 (i.e., the first track). Use with limit to get the next set of entities.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Paging<FullArtist> GetUsersTopArtists(TimeRangeType timeRange = TimeRangeType.MediumTerm, int limit = 20, int offest = 0);

        /// <summary>
        ///     Get the current user’s top artists based on calculated affinity asynchronously.
        /// </summary>
        /// <param name="timeRange">Over what time frame the affinities are computed.
        /// Valid values: long_term (calculated from several years of data and including all new data as it becomes available),
        /// medium_term (approximately last 6 months), short_term (approximately last 4 weeks). </param>
        /// <param name="limit">The number of entities to return. Default: 20. Minimum: 1. Maximum: 50</param>
        /// <param name="offest">The index of the first entity to return. Default: 0 (i.e., the first track). Use with limit to get the next set of entities.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<Paging<FullArtist>> GetUsersTopArtistsAsync(TimeRangeType timeRange = TimeRangeType.MediumTerm, int limit = 20, int offest = 0);

        /// <summary>
        ///     Get tracks from the current user’s recent play history.
        /// </summary>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="after">A Unix timestamp in milliseconds. Returns all items after (but not including) this cursor position. If after is specified, before must not be specified.</param>
        /// <param name="before">A Unix timestamp in milliseconds. Returns all items before (but not including) this cursor position. If before is specified, after must not be specified.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        CursorPaging<PlayHistory> GetUsersRecentlyPlayedTracks(int limit = 20, DateTime? after = null,
            DateTime? before = null);

        /// <summary>
        ///     Get tracks from the current user’s recent play history asynchronously
        /// </summary>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="after">A Unix timestamp in milliseconds. Returns all items after (but not including) this cursor position. If after is specified, before must not be specified.</param>
        /// <param name="before">A Unix timestamp in milliseconds. Returns all items before (but not including) this cursor position. If before is specified, after must not be specified.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<CursorPaging<PlayHistory>> GetUsersRecentlyPlayedTracksAsync(int limit = 20, DateTime? after = null,
            DateTime? before = null);

        /// <summary>
        ///     Get a list of the playlists owned or followed by a Spotify user.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="limit">The maximum number of playlists to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="offset">The index of the first playlist to return. Default: 0 (the first object)</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Paging<SimplePlaylist> GetUserPlaylists(string userId, int limit = 20, int offset = 0);

        /// <summary>
        ///     Get a list of the playlists owned or followed by a Spotify user asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="limit">The maximum number of playlists to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="offset">The index of the first playlist to return. Default: 0 (the first object)</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<Paging<SimplePlaylist>> GetUserPlaylistsAsync(string userId, int limit = 20, int offset = 0);

        /// <summary>
        ///     Get a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="fields">
        ///     Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are
        ///     returned.
        /// </param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        FullPlaylist GetPlaylist(string userId, string playlistId, string fields = "", string market = "");

        /// <summary>
        ///     Get a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="fields">
        ///     Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are
        ///     returned.
        /// </param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        FullPlaylist GetPlaylist(string playlistId, string fields = "", string market = "");

        /// <summary>
        ///     Get a playlist owned by a Spotify user asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="fields">
        ///     Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are
        ///     returned.
        /// </param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<FullPlaylist> GetPlaylistAsync(string userId, string playlistId, string fields = "", string market = "");

        /// <summary>
        ///     Get a playlist owned by a Spotify user asynchronously.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="fields">
        ///     Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are
        ///     returned.
        /// </param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<FullPlaylist> GetPlaylistAsync(string playlistId, string fields = "", string market = "");

        /// <summary>
        ///     Get full details of the tracks of a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="fields">
        ///     Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are
        ///     returned.
        /// </param>
        /// <param name="limit">The maximum number of tracks to return. Default: 100. Minimum: 1. Maximum: 100.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Paging<PlaylistTrack> GetPlaylistTracks(string userId, string playlistId, string fields = "", int limit = 100, int offset = 0, string market = "");

        /// <summary>
        ///     Get full details of the tracks of a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="fields">
        ///     Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are
        ///     returned.
        /// </param>
        /// <param name="limit">The maximum number of tracks to return. Default: 100. Minimum: 1. Maximum: 100.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Paging<PlaylistTrack> GetPlaylistTracks(string playlistId, string fields = "", int limit = 100, int offset = 0, string market = "");

        /// <summary>
        ///     Get full details of the tracks of a playlist owned by a Spotify user asyncronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="fields">
        ///     Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are
        ///     returned.
        /// </param>
        /// <param name="limit">The maximum number of tracks to return. Default: 100. Minimum: 1. Maximum: 100.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<Paging<PlaylistTrack>> GetPlaylistTracksAsync(string userId, string playlistId, string fields = "", int limit = 100, int offset = 0, string market = "");

        /// <summary>
        ///     Get full details of the tracks of a playlist owned by a Spotify user asyncronously.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="fields">
        ///     Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are
        ///     returned.
        /// </param>
        /// <param name="limit">The maximum number of tracks to return. Default: 100. Minimum: 1. Maximum: 100.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<Paging<PlaylistTrack>> GetPlaylistTracksAsync(string playlistId, string fields = "", int limit = 100, int offset = 0, string market = "");

        /// <summary>
        ///     Create a playlist for a Spotify user. (The playlist will be empty until you add tracks.)
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistName">
        ///     The name for the new playlist, for example "Your Coolest Playlist". This name does not need
        ///     to be unique.
        /// </param>
        /// <param name="isPublic">
        ///     default true. If true the playlist will be public, if false it will be private. To be able to
        ///     create private playlists, the user must have granted the playlist-modify-private scope.
        /// </param>
        /// <param name="isCollaborative">If true the playlist will become collaborative and other users will be able to modify the playlist in their Spotify client.
        /// Note: You can only set collaborative to true on non-public playlists.</param>
        /// <param name="playlistDescription">Value for playlist description as displayed in Spotify Clients and in the Web API.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        FullPlaylist CreatePlaylist(string userId, string playlistName, bool isPublic = true, bool isCollaborative = false, string playlistDescription = "");

        /// <summary>
        ///     Create a playlist for a Spotify user asynchronously. (The playlist will be empty until you add tracks.)
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistName">
        ///     The name for the new playlist, for example "Your Coolest Playlist". This name does not need
        ///     to be unique.
        /// </param>
        /// <param name="isPublic">
        ///     default true. If true the playlist will be public, if false it will be private. To be able to
        ///     create private playlists, the user must have granted the playlist-modify-private scope.
        /// </param>
        /// <param name="isCollaborative">If true the playlist will become collaborative and other users will be able to modify the playlist in their Spotify client.
        /// Note: You can only set collaborative to true on non-public playlists.</param>
        /// <param name="playlistDescription">Value for playlist description as displayed in Spotify Clients and in the Web API.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<FullPlaylist> CreatePlaylistAsync(string userId, string playlistName, bool isPublic = true, bool isCollaborative = false, string playlistDescription = "");

        /// <summary>
        ///     Change a playlist’s name and public/private state. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="newName">The new name for the playlist, for example "My New Playlist Title".</param>
        /// <param name="newPublic">If true the playlist will be public, if false it will be private.</param>
        /// <param name="newCollaborative">If true the playlist will become collaborative and other users will be able to modify the playlist in their Spotify client.
        /// Note: You can only set collaborative to true on non-public playlists.</param>
        /// <param name="newDescription">Value for playlist description as displayed in Spotify Clients and in the Web API.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse UpdatePlaylist(string userId, string playlistId, string newName = null, bool? newPublic = null, bool? newCollaborative = null, string newDescription = null);

        /// <summary>
        ///     Change a playlist’s name and public/private state. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="newName">The new name for the playlist, for example "My New Playlist Title".</param>
        /// <param name="newPublic">If true the playlist will be public, if false it will be private.</param>
        /// <param name="newCollaborative">If true the playlist will become collaborative and other users will be able to modify the playlist in their Spotify client.
        /// Note: You can only set collaborative to true on non-public playlists.</param>
        /// <param name="newDescription">Value for playlist description as displayed in Spotify Clients and in the Web API.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse UpdatePlaylist(string playlistId, string newName = null, bool? newPublic = null, bool? newCollaborative = null, string newDescription = null);

        /// <summary>
        ///     Change a playlist’s name and public/private state asynchronously. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="newName">The new name for the playlist, for example "My New Playlist Title".</param>
        /// <param name="newPublic">If true the playlist will be public, if false it will be private.</param>
        /// <param name="newCollaborative">If true the playlist will become collaborative and other users will be able to modify the playlist in their Spotify client. Note: You can only set collaborative to true on non-public playlists.</param>
        /// <param name="newDescription">Value for playlist description as displayed in Spotify Clients and in the Web API.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> UpdatePlaylistAsync(string userId, string playlistId, string newName = null, bool? newPublic = null, bool? newCollaborative = null, string newDescription = null);

        /// <summary>
        ///     Change a playlist’s name and public/private state asynchronously. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="newName">The new name for the playlist, for example "My New Playlist Title".</param>
        /// <param name="newPublic">If true the playlist will be public, if false it will be private.</param>
        /// <param name="newCollaborative">If true the playlist will become collaborative and other users will be able to modify the playlist in their Spotify client. Note: You can only set collaborative to true on non-public playlists.</param>
        /// <param name="newDescription">Value for playlist description as displayed in Spotify Clients and in the Web API.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> UpdatePlaylistAsync(string playlistId, string newName = null, bool? newPublic = null, bool? newCollaborative = null, string newDescription = null);

        /// <summary>
        ///     Change a playlist’s name and public/private state. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="base64EncodedJpgImage">The image as a base64 encoded string</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse UploadPlaylistImage(string userId, string playlistId, string base64EncodedJpgImage);

        /// <summary>
        ///     Change a playlist’s name and public/private state asynchronously. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="base64EncodedJpgImage">The image as a base64 encoded string</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> UploadPlaylistImageAsync(string userId, string playlistId, string base64EncodedJpgImage);

        /// <summary>
        ///     Change a playlist’s name and public/private state. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="base64EncodedJpgImage">The image as a base64 encoded string</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse UploadPlaylistImage(string playlistId, string base64EncodedJpgImage);

        /// <summary>
        ///     Change a playlist’s name and public/private state asynchronously. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="base64EncodedJpgImage">The image as a base64 encoded string</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> UploadPlaylistImageAsync(string playlistId, string base64EncodedJpgImage);

        /// <summary>
        ///     Replace all the tracks in a playlist, overwriting its existing tracks. This powerful request can be useful for
        ///     replacing tracks, re-ordering existing tracks, or clearing the playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to set. A maximum of 100 tracks can be set in one request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse ReplacePlaylistTracks(string userId, string playlistId, List<string> uris);

        /// <summary>
        ///     Replace all the tracks in a playlist, overwriting its existing tracks. This powerful request can be useful for
        ///     replacing tracks, re-ordering existing tracks, or clearing the playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to set. A maximum of 100 tracks can be set in one request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse ReplacePlaylistTracks(string playlistId, List<string> uris);

        /// <summary>
        ///     Replace all the tracks in a playlist asynchronously, overwriting its existing tracks. This powerful request can be useful for
        ///     replacing tracks, re-ordering existing tracks, or clearing the playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to set. A maximum of 100 tracks can be set in one request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> ReplacePlaylistTracksAsync(string userId, string playlistId, List<string> uris);

        /// <summary>
        ///     Replace all the tracks in a playlist asynchronously, overwriting its existing tracks. This powerful request can be useful for
        ///     replacing tracks, re-ordering existing tracks, or clearing the playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to set. A maximum of 100 tracks can be set in one request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> ReplacePlaylistTracksAsync(string playlistId, List<string> uris);

        /// <summary>
        ///     Remove one or more tracks from a user’s playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">
        ///     array of objects containing Spotify URI strings (and their position in the playlist). A maximum of
        ///     100 objects can be sent at once.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse RemovePlaylistTracks(string userId, string playlistId, List<DeleteTrackUri> uris);

        /// <summary>
        ///     Remove one or more tracks from a user’s playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">
        ///     array of objects containing Spotify URI strings (and their position in the playlist). A maximum of
        ///     100 objects can be sent at once.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse RemovePlaylistTracks(string playlistId, List<DeleteTrackUri> uris);

        /// <summary>
        ///     Remove one or more tracks from a user’s playlist asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">
        ///     array of objects containing Spotify URI strings (and their position in the playlist). A maximum of
        ///     100 objects can be sent at once.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> RemovePlaylistTracksAsync(string userId, string playlistId, List<DeleteTrackUri> uris);

        /// <summary>
        ///     Remove one or more tracks from a user’s playlist asynchronously.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">
        ///     array of objects containing Spotify URI strings (and their position in the playlist). A maximum of
        ///     100 objects can be sent at once.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> RemovePlaylistTracksAsync(string playlistId, List<DeleteTrackUri> uris);

        /// <summary>
        ///     Remove a track from a user’s playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">Spotify URI</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse RemovePlaylistTrack(string userId, string playlistId, DeleteTrackUri uri);

        /// <summary>
        ///     Remove a track from a user’s playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">Spotify URI</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse RemovePlaylistTrack(string playlistId, DeleteTrackUri uri);

        /// <summary>
        ///     Remove a track from a user’s playlist asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">Spotify URI</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> RemovePlaylistTrackAsync(string userId, string playlistId, DeleteTrackUri uri);

        /// <summary>
        ///     Remove a track from a user’s playlist asynchronously.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">Spotify URI</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> RemovePlaylistTrackAsync(string playlistId, DeleteTrackUri uri);

        /// <summary>
        ///     Add one or more tracks to a user’s playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to add</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse AddPlaylistTracks(string userId, string playlistId, List<string> uris, int? position = null);

        /// <summary>
        ///     Add one or more tracks to a user’s playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to add</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse AddPlaylistTracks(string playlistId, List<string> uris, int? position = null);

        /// <summary>
        ///     Add one or more tracks to a user’s playlist asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to add</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> AddPlaylistTracksAsync(string userId, string playlistId, List<string> uris, int? position = null);

        /// <summary>
        ///     Add one or more tracks to a user’s playlist asynchronously.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to add</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> AddPlaylistTracksAsync(string playlistId, List<string> uris, int? position = null);

        /// <summary>
        ///     Add a track to a user’s playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">A Spotify Track URI</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse AddPlaylistTrack(string userId, string playlistId, string uri, int? position = null);

        /// <summary>
        ///     Add a track to a user’s playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">A Spotify Track URI</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        ErrorResponse AddPlaylistTrack(string playlistId, string uri, int? position = null);

        /// <summary>
        ///     Add a track to a user’s playlist asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">A Spotify Track URI</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> AddPlaylistTrackAsync(string userId, string playlistId, string uri, int? position = null);

        /// <summary>
        ///     Add a track to a user’s playlist asynchronously.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">A Spotify Track URI</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<ErrorResponse> AddPlaylistTrackAsync(string playlistId, string uri, int? position = null);

        /// <summary>
        ///     Reorder a track or a group of tracks in a playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="rangeStart">The position of the first track to be reordered.</param>
        /// <param name="insertBefore">The position where the tracks should be inserted. </param>
        /// <param name="rangeLength">The amount of tracks to be reordered. Defaults to 1 if not set.</param>
        /// <param name="snapshotId">The playlist's snapshot ID against which you want to make the changes.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Snapshot ReorderPlaylist(string userId, string playlistId, int rangeStart, int insertBefore, int rangeLength = 1, string snapshotId = "");

        /// <summary>
        ///     Reorder a track or a group of tracks in a playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="rangeStart">The position of the first track to be reordered.</param>
        /// <param name="insertBefore">The position where the tracks should be inserted. </param>
        /// <param name="rangeLength">The amount of tracks to be reordered. Defaults to 1 if not set.</param>
        /// <param name="snapshotId">The playlist's snapshot ID against which you want to make the changes.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Snapshot ReorderPlaylist(string playlistId, int rangeStart, int insertBefore, int rangeLength = 1, string snapshotId = "");

        /// <summary>
        ///     Reorder a track or a group of tracks in a playlist asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="rangeStart">The position of the first track to be reordered.</param>
        /// <param name="insertBefore">The position where the tracks should be inserted. </param>
        /// <param name="rangeLength">The amount of tracks to be reordered. Defaults to 1 if not set.</param>
        /// <param name="snapshotId">The playlist's snapshot ID against which you want to make the changes.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<Snapshot> ReorderPlaylistAsync(string userId, string playlistId, int rangeStart, int insertBefore, int rangeLength = 1, string snapshotId = "");

        /// <summary>
        ///     Reorder a track or a group of tracks in a playlist asynchronously.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="rangeStart">The position of the first track to be reordered.</param>
        /// <param name="insertBefore">The position where the tracks should be inserted. </param>
        /// <param name="rangeLength">The amount of tracks to be reordered. Defaults to 1 if not set.</param>
        /// <param name="snapshotId">The playlist's snapshot ID against which you want to make the changes.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<Snapshot> ReorderPlaylistAsync(string playlistId, int rangeStart, int insertBefore, int rangeLength = 1, string snapshotId = "");

        /// <summary>
        ///     Get detailed profile information about the current user (including the current user’s username).
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        PrivateProfile GetPrivateProfile();

        /// <summary>
        ///     Get detailed profile information about the current user asynchronously (including the current user’s username).
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<PrivateProfile> GetPrivateProfileAsync();

        /// <summary>
        ///     Get public profile information about a Spotify user.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <returns></returns>
        PublicProfile GetPublicProfile(string userId);

        /// <summary>
        ///     Get public profile information about a Spotify user asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <returns></returns>
        Task<PublicProfile> GetPublicProfileAsync(string userId);

        /// <summary>
        ///     Get Spotify catalog information for multiple tracks based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the tracks. Maximum: 50 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        SeveralTracks GetSeveralTracks(List<string> ids, string market = "");

        /// <summary>
        ///     Get Spotify catalog information for multiple tracks based on their Spotify IDs asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the tracks. Maximum: 50 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        Task<SeveralTracks> GetSeveralTracksAsync(List<string> ids, string market = "");

        /// <summary>
        ///     Get Spotify catalog information for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        FullTrack GetTrack(string id, string market = "");

        /// <summary>
        ///     Get Spotify catalog information for a single track identified by its unique Spotify ID asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        Task<FullTrack> GetTrackAsync(string id, string market = "");

        /// <summary>
        ///     Get a detailed audio analysis for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        AudioAnalysis GetAudioAnalysis(string id);

        /// <summary>
        ///     Get a detailed audio analysis for a single track identified by its unique Spotify ID asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<AudioAnalysis> GetAudioAnalysisAsync(string id);

        /// <summary>
        ///     Get audio feature information for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        AudioFeatures GetAudioFeatures(string id);

        /// <summary>
        ///     Get audio feature information for a single track identified by its unique Spotify ID asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<AudioFeatures> GetAudioFeaturesAsync(string id);

        /// <summary>
        ///     Get audio features for multiple tracks based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of Spotify Track-IDs. Maximum: 100 IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        SeveralAudioFeatures GetSeveralAudioFeatures(List<string> ids);

        /// <summary>
        ///     Get audio features for multiple tracks based on their Spotify IDs asynchronously.
        /// </summary>
        /// <param name="ids">A list of Spotify Track-IDs. Maximum: 100 IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        Task<SeveralAudioFeatures> GetSeveralAudioFeaturesAsync(List<string> ids);

        /// <summary>
        ///     Get information about a user’s available devices.
        /// </summary>
        /// <returns></returns>
        AvailabeDevices GetDevices();

        /// <summary>
        ///     Get information about a user’s available devices.
        /// </summary>
        /// <returns></returns>
        Task<AvailabeDevices> GetDevicesAsync();

        /// <summary>
        ///     Get information about the user’s current playback state, including track, track progress, and active device.
        /// </summary>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        PlaybackContext GetPlayback(string market = "");

        /// <summary>
        ///     Get information about the user’s current playback state, including track, track progress, and active device.
        /// </summary>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        Task<PlaybackContext> GetPlaybackAsync(string market = "");

        /// <summary>
        ///     Get the object currently being played on the user’s Spotify account.
        /// </summary>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        PlaybackContext GetPlayingTrack(string market = "");

        /// <summary>
        ///     Get the object currently being played on the user’s Spotify account.
        /// </summary>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        Task<PlaybackContext> GetPlayingTrackAsync(string market = "");

        /// <summary>
        ///     Transfer playback to a new device and determine if it should start playing.
        /// </summary>
        /// <param name="deviceId">ID of the device on which playback should be started/transferred to</param>
        /// <param name="play">
        /// true: ensure playback happens on new device.
        /// false or not provided: keep the current playback state.
        /// </param>
        /// <returns></returns>
        ErrorResponse TransferPlayback(string deviceId, bool play = false);

        /// <summary>
        ///     Transfer playback to a new device and determine if it should start playing.
        /// </summary>
        /// <param name="deviceId">ID of the device on which playback should be started/transferred to</param>
        /// <param name="play">
        /// true: ensure playback happens on new device.
        /// false or not provided: keep the current playback state.
        /// </param>
        /// <returns></returns>
        Task<ErrorResponse> TransferPlaybackAsync(string deviceId, bool play = false);

        /// <summary>
        ///     Transfer playback to a new device and determine if it should start playing.
        ///     NOTE: Although an array is accepted, only a single device_id is currently supported. Supplying more than one will return 400 Bad Request
        /// </summary>
        /// <param name="deviceIds">A array containing the ID of the device on which playback should be started/transferred.</param>
        /// <param name="play">
        /// true: ensure playback happens on new device.
        /// false or not provided: keep the current playback state.
        /// </param>
        /// <returns></returns>
        ErrorResponse TransferPlayback(List<string> deviceIds, bool play = false);

        /// <summary>
        ///     Transfer playback to a new device and determine if it should start playing.
        ///     NOTE: Although an array is accepted, only a single device_id is currently supported. Supplying more than one will return 400 Bad Request
        /// </summary>
        /// <param name="deviceIds">A array containing the ID of the device on which playback should be started/transferred.</param>
        /// <param name="play">
        /// true: ensure playback happens on new device.
        /// false or not provided: keep the current playback state.
        /// </param>
        /// <returns></returns>
        Task<ErrorResponse> TransferPlaybackAsync(List<string> deviceIds, bool play = false);

        /// <summary>
        ///     Start a new context or resume current playback on the user’s active device.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <param name="contextUri">Spotify URI of the context to play.</param>
        /// <param name="uris">A JSON array of the Spotify track URIs to play.</param>
        /// <param name="offset">Indicates from where in the context playback should start.
        /// Only available when context_uri corresponds to an album or playlist object, or when the uris parameter is used.</param>
        /// <param name="positionMs">The starting time to seek the track to</param>
        /// <returns></returns>
        ErrorResponse ResumePlayback(string deviceId = "", string contextUri = "", List<string> uris = null,
            int? offset = null, int positionMs = 0);

        /// <summary>
        ///     Start a new context or resume current playback on the user’s active device.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <param name="contextUri">Spotify URI of the context to play.</param>
        /// <param name="uris">A JSON array of the Spotify track URIs to play.</param>
        /// <param name="offset">Indicates from where in the context playback should start.
        /// Only available when context_uri corresponds to an album or playlist object, or when the uris parameter is used.</param>
        /// <param name="positionMs">The starting time to seek the track to</param>
        /// <returns></returns>
        Task<ErrorResponse> ResumePlaybackAsync(string deviceId = "", string contextUri = "", List<string> uris = null,
            int? offset = null, int positionMs = 0);

        /// <summary>
        ///     Start a new context or resume current playback on the user’s active device.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <param name="contextUri">Spotify URI of the context to play.</param>
        /// <param name="uris">A JSON array of the Spotify track URIs to play.</param>
        /// <param name="offset">Indicates from where in the context playback should start.
        /// Only available when context_uri corresponds to an album or playlist object, or when the uris parameter is used.</param>
        /// <param name="positionMs">The starting time to seek the track to</param>
        /// <returns></returns>
        ErrorResponse ResumePlayback(string deviceId = "", string contextUri = "", List<string> uris = null,
            string offset = "", int positionMs = 0);

        /// <summary>
        ///     Start a new context or resume current playback on the user’s active device.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <param name="contextUri">Spotify URI of the context to play.</param>
        /// <param name="uris">A JSON array of the Spotify track URIs to play.</param>
        /// <param name="offset">Indicates from where in the context playback should start.
        /// Only available when context_uri corresponds to an album or playlist object, or when the uris parameter is used.</param>
        /// <param name="positionMs">The starting time to seek the track to</param>
        /// <returns></returns>
        Task<ErrorResponse> ResumePlaybackAsync(string deviceId = "", string contextUri = "", List<string> uris = null,
            string offset = "", int positionMs = 0);

        /// <summary>
        ///     Pause playback on the user’s account.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        ErrorResponse PausePlayback(string deviceId = "");

        /// <summary>
        ///     Pause playback on the user’s account.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        Task<ErrorResponse> PausePlaybackAsync(string deviceId = "");

        /// <summary>
        ///     Skips to next track in the user’s queue.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        ErrorResponse SkipPlaybackToNext(string deviceId = "");

        /// <summary>
        ///     Skips to next track in the user’s queue.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        Task<ErrorResponse> SkipPlaybackToNextAsync(string deviceId = "");

        /// <summary>
        ///     Skips to previous track in the user’s queue.
        ///     Note that this will ALWAYS skip to the previous track, regardless of the current track’s progress.
        ///     Returning to the start of the current track should be performed using the https://api.spotify.com/v1/me/player/seek endpoint.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        ErrorResponse SkipPlaybackToPrevious(string deviceId = "");

        /// <summary>
        ///     Skips to previous track in the user’s queue.
        ///     Note that this will ALWAYS skip to the previous track, regardless of the current track’s progress.
        ///     Returning to the start of the current track should be performed using the https://api.spotify.com/v1/me/player/seek endpoint.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        Task<ErrorResponse> SkipPlaybackToPreviousAsync(string deviceId = "");

        /// <summary>
        ///     Seeks to the given position in the user’s currently playing track.
        /// </summary>
        /// <param name="positionMs">The position in milliseconds to seek to. Must be a positive number.
        /// Passing in a position that is greater than the length of the track will cause the player to start playing the next song.</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        ErrorResponse SeekPlayback(int positionMs, string deviceId = "");

        /// <summary>
        ///     Seeks to the given position in the user’s currently playing track.
        /// </summary>
        /// <param name="positionMs">The position in milliseconds to seek to. Must be a positive number.
        /// Passing in a position that is greater than the length of the track will cause the player to start playing the next song.</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        Task<ErrorResponse> SeekPlaybackAsync(int positionMs, string deviceId = "");

        /// <summary>
        ///     Set the repeat mode for the user’s playback. Options are repeat-track, repeat-context, and off.
        /// </summary>
        /// <param name="state">track, context or off. </param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        ErrorResponse SetRepeatMode(RepeatState state, string deviceId = "");

        /// <summary>
        ///     Set the repeat mode for the user’s playback. Options are repeat-track, repeat-context, and off.
        /// </summary>
        /// <param name="state">track, context or off. </param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        Task<ErrorResponse> SetRepeatModeAsync(RepeatState state, string deviceId = "");

        /// <summary>
        ///     Set the volume for the user’s current playback device.
        /// </summary>
        /// <param name="volumePercent">Integer. The volume to set. Must be a value from 0 to 100 inclusive.</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        ErrorResponse SetVolume(int volumePercent, string deviceId = "");

        /// <summary>
        ///     Set the volume for the user’s current playback device.
        /// </summary>
        /// <param name="volumePercent">Integer. The volume to set. Must be a value from 0 to 100 inclusive.</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        Task<ErrorResponse> SetVolumeAsync(int volumePercent, string deviceId = "");

        /// <summary>
        ///     Toggle shuffle on or off for user’s playback.
        /// </summary>
        /// <param name="shuffle">True or False</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        ErrorResponse SetShuffle(bool shuffle, string deviceId = "");

        /// <summary>
        ///     Toggle shuffle on or off for user’s playback.
        /// </summary>
        /// <param name="shuffle">True or False</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        Task<ErrorResponse> SetShuffleAsync(bool shuffle, string deviceId = "");

        /// <summary>
        ///     Add an Item to the User's Playback Queue. BETA
        /// </summary>
        /// <param name="uri">The uri of the item to add to the queue. Must be a track or an episode uri.</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns></returns>
        ErrorResponse AddToQueue(string uri, string deviceId = "");

        /// <summary>
        ///     Add an Item to the User's Playback Queue. BETA
        /// </summary>
        /// <param name="uri">The uri of the item to add to the queue. Must be a track or an episode uri.</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user’s currently active device is the target.</param>
        /// <returns></returns>
        Task<ErrorResponse> AddToQueueAsync(string uri, string deviceId = "");

        TOut GetNextPage<TOut, TIn>(Paging<TIn> paging) where TOut : BasicModel;
        TOut GetNextPage<TOut, TIn>(CursorPaging<TIn> paging) where TOut : BasicModel;
        Paging<T> GetNextPage<T>(Paging<T> paging);
        CursorPaging<T> GetNextPage<T>(CursorPaging<T> paging);
        Task<TOut> GetNextPageAsync<TOut, TIn>(Paging<TIn> paging) where TOut : BasicModel;
        Task<TOut> GetNextPageAsync<TOut, TIn>(CursorPaging<TIn> paging) where TOut : BasicModel;
        Task<Paging<T>> GetNextPageAsync<T>(Paging<T> paging);
        Task<CursorPaging<T>> GetNextPageAsync<T>(CursorPaging<T> paging);
        TOut GetPreviousPage<TOut, TIn>(Paging<TIn> paging) where TOut : BasicModel;
        Paging<T> GetPreviousPage<T>(Paging<T> paging);
        Task<TOut> GetPreviousPageAsync<TOut, TIn>(Paging<TIn> paging) where TOut : BasicModel;
        Task<Paging<T>> GetPreviousPageAsync<T>(Paging<T> paging);
        T UploadData<T>(string url, string uploadData, string method = "POST") where T : BasicModel;
        Task<T> UploadDataAsync<T>(string url, string uploadData, string method = "POST") where T : BasicModel;
        T DownloadData<T>(string url) where T : BasicModel;
        Task<T> DownloadDataAsync<T>(string url) where T : BasicModel;
    }
}