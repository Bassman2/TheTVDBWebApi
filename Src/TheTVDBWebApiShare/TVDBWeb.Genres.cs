namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns list of genre records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of genre records.</returns>
        public async Task<List<GenreBaseRecord>> GetGenresAsync(CancellationToken cancellationToken = default)
        {
            Response<List<GenreBaseRecord>> resp = await GetAsync<List<GenreBaseRecord>>("v4/genres", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns genre record.
        /// </summary>
        /// <param name="id">Id of the episode to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Genre record.</returns>
        public async Task<GenreBaseRecord> GetGenreAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<GenreBaseRecord> resp = await GetAsync<GenreBaseRecord>($"v4/genres/{id}", cancellationToken);
            return resp.Data;
        }
    }
}
