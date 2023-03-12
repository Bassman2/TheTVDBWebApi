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
        /// Returns a list of status records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of status records</returns>
        public async Task<List<Status>> GetSeriesStatusesAsync(CancellationToken cancellationToken = default)
        {
            Response<List<Status>> resp = await GetAsync<List<Status>>($"v4/series/statuses", cancellationToken);
            return resp.Data;
        }
    }
}
