namespace TheTVDBWebApi
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns number of episodes base records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Number of episodes base records.</returns>
        public async Task<long> GetListsNumAsync(CancellationToken cancellationToken = default)
        {
            return await GetNumAsync("v4/lists", cancellationToken);
        }

        /// <summary>
        /// Returns list of episodes base records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of episodes base records.</returns>
        public IAsyncEnumerable<ListBaseRecord> GetListsAsync(CancellationToken cancellationToken = default)
        {
            return GetYieldAsync<ListBaseRecord>("v4/lists", cancellationToken);
        }

        /// <summary>
        /// Returns an list base record.
        /// </summary>
        /// <param name="id">Id of the list to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List base record.</returns>
        public async Task<ListBaseRecord?> GetListAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<ListBaseRecord>($"v4/lists/{id}", cancellationToken);
        }

        /// <summary>
        /// Returns an list base record search by slug.
        /// </summary>
        /// <param name="slug">Slug of the list to get. For lists Slug is identically to the Url property.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List base record.</returns>
        public async Task<ListBaseRecord?> GetListBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<ListBaseRecord>($"v4/lists/slug/{slug}", cancellationToken);
        }

        /// <summary>
        /// Returns an list extended record.
        /// </summary>
        /// <param name="id">Id of the list to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List extended record.</returns>
        public async Task<ListExtendedRecord?> GetListExtendedAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<ListExtendedRecord>($"v4/lists/{id}/extended", cancellationToken);
        }

        /// <summary>
        /// Returns list translation record.
        /// </summary>
        /// <param name="id">Id of the list to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List translation record.</returns>
        public async Task<List<Translation>?> GetListTranslationAsync(long id, string language, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<Translation>>($"v4/lists/{id}/translations/{language}", cancellationToken);
        }
    }
}
