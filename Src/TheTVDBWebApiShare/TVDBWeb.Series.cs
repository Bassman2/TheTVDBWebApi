using System.Reflection;

namespace TheTVDBWebApiShare
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
        public async IAsyncEnumerable<SeriesBaseRecord> GetSeriesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string requestUri = "v4/series?page=0";
            while (!string.IsNullOrEmpty(requestUri))
            {
                Response<List<SeriesBaseRecord>> resp = await GetAsync<List<SeriesBaseRecord>>(requestUri, cancellationToken);
                foreach (SeriesBaseRecord serie in resp.Data)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }
                    yield return serie;
                }
                requestUri = resp.Links.Next;
            }
        }

        /// <summary>
        /// Returns series base record.
        /// </summary>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Series base record.</returns>
        public async Task<SeriesBaseRecord> GetSeriesAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<SeriesBaseRecord>($"v4/series/{id}", cancellationToken);
        }

        /// <summary>
        /// Returns series extended record.
        /// </summary>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="language">Language</param>
        /// <param name="type">Type of the artwork.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Series extended record.</returns>
        public async Task<ArtworkBaseRecord> GetSeriesArtworkAsync(long id, string language, int type, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<ArtworkBaseRecord>($"v4/series/{id}/artworks&lang={language}&type={type}", cancellationToken);
        }

        /// <summary>
        /// Returns series base record including the nextAired field.
        /// </summary>
        /// <remarks>NextAired was included in the base record endpoint but that field will deprecated in the future so developers should use the nextAired endpoint.</remarks>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Series base record.</returns>
        public async Task<SeriesBaseRecord> GetSeriesNextAiredAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<SeriesBaseRecord>($"v4/series/{id}/nextAired", cancellationToken);
        }

        /// <summary>
        /// Returns series extended record.
        /// </summary>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Series extended record.</returns>
        public async Task<SeriesExtendedRecord> GetSeriesExtendedAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<SeriesExtendedRecord>($"v4/series/{id}/extended", cancellationToken);
        }

        /// <summary>
        /// Returns series episodes from the specified season type, default returns the episodes in the series default season type.
        /// </summary>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Episode base record.</returns>
        public IAsyncEnumerable<EpisodeBaseRecord> GetSeriesEpisodesAsync(long id, SeasonType seasonType, int season, int episodeNumber, string airDate, CancellationToken cancellationToken = default)
        {
            return GetLongListAsync<EpisodeBaseRecord>($"v4/series/{id}/episodes/{seasonType.Name}?season={season}&episodeNumber={episodeNumber}&airDate={airDate}", cancellationToken);
        }

        /// <summary>
        /// Returns series episodes from the specified season type, default returns the episodes in the series default season type.
        /// </summary>
        /// <param name="id">Id of the series to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Episode base record.</returns>
        public IAsyncEnumerable<EpisodeBaseRecord> GetSeriesEpisodesAsync(long id, SeasonType seasonType, string language, CancellationToken cancellationToken = default)
        {
            return GetLongListAsync<EpisodeBaseRecord>($"v4/series/{id}/episodes/{seasonType.Name}/{language}", cancellationToken);
        }

        /// <summary>
        /// Rearch series based on filter parameters
        /// </summary>
        /// <remarks>NextAired was included in the base record endpoint but that field will deprecated in the future so developers should use the nextAired endpoint.</remarks>
        /// <param name="filter">Filter to search for.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of series base record.</returns>
        public async Task<List<SeriesBaseRecord>> GetSeriesFilterAsync(SeriesFilter filter, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<SeriesBaseRecord>>($"v4/series/filter&{filter}", cancellationToken);
        }

        /// <summary>
        /// Series base record search by slug.
        /// </summary>
        /// <param name="slug">Slug to search for.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Series base record.</returns>
        public async Task<SeriesBaseRecord> GetSeriesSlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<SeriesBaseRecord>($"v4/series/slug/{slug}", cancellationToken);
        }

        /// <summary>
        /// Returns series translation record.
        /// </summary>
        /// <param name="id">Id of the series.</param>
        /// <param name="language">Lanuage of the translations.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Translation record.</returns>
        public async Task<Translation> GetSeriesTranslationAsync(string id, string language, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<Translation>($"v4/series/{id}/translations/{language}", cancellationToken);
        }

        /// <summary>
        /// Returns a list of status records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of status records</returns>
        public async Task<List<Status>> GetSeriesStatusesAsync(CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<Status>>($"v4/series/statuses", cancellationToken);
        }
    }
}
