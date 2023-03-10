using System.IO;

namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Our search index includes series, movies, people, and companies. Search is limited to 5k results max.
        /// </summary>
        /// <param name="filter">Search filter.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Search result.</returns>
        public async IAsyncEnumerable<SearchResult> GetSearchAsync(SearchFilter filter, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string requestUri = $"v4/search?{filter.Parameter}";
            while (!string.IsNullOrEmpty(requestUri))
            {
                Response<List<SearchResult>> resp = await GetAsync<List<SearchResult>>(requestUri, cancellationToken);
                foreach (var res in resp.Data)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }
                    yield return res;
                }
                requestUri = resp.Links.Next;
            }
        }

        /// <summary>
        /// Search a series, movie, people, episode, company or season by specific remote id and returns a base record for that entity.
        /// </summary>
        /// <param name="remoteId">Search for a specific remote id.Allows searching for an IMDB or EIDR id, for example.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Search by remote reuslt is a base record for a movie, series, people, season or company search result.</returns>
        public async Task<List<SearchByRemoteIdResult>> GetSearchAsync(string remoteId, CancellationToken cancellationToken = default)
        {
            Response<List<SearchByRemoteIdResult>> resp = await GetAsync<List<SearchByRemoteIdResult>>($"v4/search/remoteid/{remoteId}", cancellationToken);
            return resp.Data;
        }
    }
}
