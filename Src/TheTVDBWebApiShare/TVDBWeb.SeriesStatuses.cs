namespace TheTVDBWebApiShare
{
    partial class TVDBWeb
    {
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
