namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns a list of artworkType records
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of artworkType records</returns>
        public async Task<List<ArtworkStatus>> GetArtworkStatusesAsync(CancellationToken cancellationToken = default)
        {
            Response<List<ArtworkStatus>> resp = await GetAsync<List<ArtworkStatus>>($"v4/artwork/statuses", cancellationToken);
            return resp.Data;
        }
    }
}
