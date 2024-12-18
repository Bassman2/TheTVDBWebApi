﻿namespace TheTVDBWebApi
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns number of series.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Number of series.</returns>
        public async Task<long> GetSeriesNumAsync(CancellationToken cancellationToken = default)
        {
            return await GetNumAsync("v4/series", cancellationToken);
        }

        /// <summary>
        /// Returns list of series base records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of series base records.</returns>
        public IAsyncEnumerable<SeriesBaseRecord> GetSeriesAsync(CancellationToken cancellationToken = default)
        {
            return GetYieldAsync<SeriesBaseRecord>($"v4/series", cancellationToken);
        }

        /// <summary>
        /// Returns series base record.
        /// </summary>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Series base record.</returns>
        public async Task<SeriesBaseRecord?> GetSeriesAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<SeriesBaseRecord>($"v4/series/{id}", cancellationToken);
        }

        /// <summary>
        /// Returns series extended record.
        /// </summary>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="language">Language</param>
        /// <param name="type">Type of the artwork.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Series extended record.</returns>
        public async Task<ArtworkBaseRecord?> GetSeriesArtworkAsync(long id, Languages language, int type, CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<ArtworkBaseRecord>($"v4/series/{id}/artworks?lang={language}&type={type}", cancellationToken);
        }

        /// <summary>
        /// Returns series base record including the nextAired field.
        /// </summary>
        /// <remarks>NextAired was included in the base record endpoint but that field will deprecated in the future so developers should use the nextAired endpoint.</remarks>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Series base record.</returns>
        public async Task<SeriesBaseRecord?> GetSeriesNextAiredAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<SeriesBaseRecord>($"v4/series/{id}/nextAired", cancellationToken);
        }

        /// <summary>
        /// Returns series extended record.
        /// </summary>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Series extended record.</returns>
        public async Task<SeriesExtendedRecord?> GetSeriesExtendedAsync(long id, MetaSeries? meta = null, bool? shortVersion = null, CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<SeriesExtendedRecord>($"v4/series/{id}/extended{BuildParam(meta, shortVersion)}", cancellationToken);
        }

        /// <summary>
        /// Returns series episodes from the specified season type, default returns the episodes in the series default season type.
        /// </summary>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Episode base record.</returns>
        public async Task<SeriesEpisodes?> GetSeriesEpisodesAsync(long id, SeasonTypeEnum seasonType, long? season, int? episodeNumber, string airDate, CancellationToken cancellationToken = default)
        {
            var param = new StringBuilder();
            if (season.HasValue)
            {
                param.Append($"&season={season.Value}");
            }
            if (episodeNumber.HasValue)
            {
                param.Append($"&episodeNumber={episodeNumber.Value}");
            }
            if (!string.IsNullOrEmpty(airDate))
            {
                param.Append($"&airDate={airDate}");
            }
            string par = param.ToString().TrimStart('&');
            return await GetFromJsonAsync<SeriesEpisodes>($"v4/series/{id}/episodes/{seasonType.ToString().ToLower()}?{par}", cancellationToken);
        }

        /// <summary>
        /// Returns series episodes from the specified season type, default returns the episodes in the series default season type.
        /// </summary>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Episode base record.</returns>
        public async Task<SeriesBaseRecord?> GetSeriesEpisodesAsync(long id, SeasonTypeEnum seasonType, Languages language, CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<SeriesBaseRecord>($"v4/series/{id}/episodes/{seasonType.ToString().ToLower()}/{language}", cancellationToken);
        }

        /// <summary>
        /// Rearch series based on filter parameters
        /// </summary>
        /// <remarks>NextAired was included in the base record endpoint but that field will deprecated in the future so developers should use the nextAired endpoint.</remarks>
        /// <param name="filter">Filter to search for.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of series base record.</returns>
        public IAsyncEnumerable<SeriesBaseRecord> GetSeriesFilterAsync(SeriesFilter filter, CancellationToken cancellationToken = default)
        {
            return GetYieldAsync<SeriesBaseRecord>($"v4/series/filter?{filter.Parameter}", cancellationToken);
        }

        /// <summary>
        /// Series base record search by slug.
        /// </summary>
        /// <param name="slug">Slug to search for.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Series base record.</returns>
        public async Task<SeriesBaseRecord?> GetSeriesSlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<SeriesBaseRecord>($"v4/series/slug/{slug}", cancellationToken);
        }

        /// <summary>
        /// Returns series translation record.
        /// </summary>
        /// <param name="id">Id of the series.</param>
        /// <param name="language">Lanuage of the translations.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Translation record.</returns>
        public async Task<Translation?> GetSeriesTranslationAsync(long id, Languages language, CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<Translation>($"v4/series/{id}/translations/{language.Value()}", cancellationToken);
        }

        /// <summary>
        /// Returns a list of status records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of status records</returns>
        public async Task<List<Status>?> GetSeriesStatusesAsync(CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<List<Status>>($"v4/series/statuses", cancellationToken);
        }
    }
}
