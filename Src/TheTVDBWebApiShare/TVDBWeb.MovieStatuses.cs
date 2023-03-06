namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns list of status records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of status records.</returns>
        public async Task<List<Status>> GetMovieStatusesAsync(CancellationToken cancellationToken = default)
        {
            Response<List<Status>> resp = await GetAsync<List<Status>>($"v4/movies/statuses", cancellationToken);
            return resp.Data;
        }
    }
}
