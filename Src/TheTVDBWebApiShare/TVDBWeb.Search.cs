namespace TheTVDBWebApi
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Our search index includes series, movies, people, and companies. Search is limited to 5k results max.
        /// </summary>
        /// <param name="filter">Search filter.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Search result.</returns>
        public IAsyncEnumerable<SearchResult> GetSearchAsync(SearchFilter filter, CancellationToken cancellationToken = default)
        {
            return GetYieldAsync<SearchResult>($"v4/search?{filter.Parameter}", cancellationToken);
        }

        /// <summary>
        /// Search a series, movie, people, episode, company or season by specific remote id and returns a base record for that entity.
        /// </summary>
        /// <param name="remoteId">Search for a specific remote id.Allows searching for an IMDB or EIDR id, for example.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Search by remote reuslt is a base record for a movie, series, people, season or company search result.</returns>
        public async Task<List<SearchByRemoteIdResult>?> GetSearchAsync(string remoteId, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<SearchByRemoteIdResult>>($"v4/search/remoteid/{remoteId}", cancellationToken);
        }
    }
}
