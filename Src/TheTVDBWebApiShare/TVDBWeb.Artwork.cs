namespace TheTVDBWebApi
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns a single artwork base record.
        /// </summary>
        /// <param name="id">Id of the artwork base record.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Single artwork base record.</returns>
        public async Task<ArtworkBaseRecord> GetArtworkAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<ArtworkBaseRecord>($"v4/artwork/{id}", cancellationToken);
        }

        /// <summary>
        /// Returns a single artwork extended record.
        /// </summary>
        /// <param name="id">Id of the artwork extended record.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Single artwork extended record.</returns>
        public async Task<ArtworkExtendedRecord> GetArtworkExtendedAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<ArtworkExtendedRecord>($"v4/artwork/{id}/extended", cancellationToken);
        }

        /// <summary>
        /// Returns a list of artworkStatus records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of artworkStatus records.</returns>
        public async Task<List<ArtworkStatus>> GetArtworkStatusesAsync(CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<ArtworkStatus>>($"v4/artwork/statuses", cancellationToken);
        }

        /// <summary>
        /// Returns a list of artworkType records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of artworkType records.</returns>
        public async Task<List<ArtworkType>> GetArtworkTypesAsync(CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<ArtworkType>>($"v4/artwork/types", cancellationToken);
        }
    }
}
