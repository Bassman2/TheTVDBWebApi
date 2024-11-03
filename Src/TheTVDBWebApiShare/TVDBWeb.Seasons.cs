namespace TheTVDBWebApi
{
    partial class TVDBWeb
    {
        /// <summary>
        /// Returns number of seasons.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Number of seasons.</returns>
        public async Task<long> GetSeasonsNumAsync(CancellationToken cancellationToken = default)
        {
            return await GetNumAsync("v4/seasons", cancellationToken);
        }

        /// <summary>
        /// Returns list of seasons base records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of seasons base records.</returns>
        public IAsyncEnumerable<SeasonBaseRecord> GetSeasonsAsync(CancellationToken cancellationToken = default)
        {
            return GetYieldAsync<SeasonBaseRecord>($"v4/seasons", cancellationToken);
        }

        /// <summary>
        /// Returns season base record.
        /// </summary>
        /// <param name="id">Id of the season to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Season base record.</returns>
        public async Task<SeasonBaseRecord?> GetSeasonAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<SeasonBaseRecord>($"v4/seasons/{id}", cancellationToken);
        }

        /// <summary>
        /// Returns season extended record.
        /// </summary>
        /// <param name="id">Id of the season to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Season extended record.</returns>
        public async Task<SeasonExtendedRecord?> GetSeasonExtendedAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<SeasonExtendedRecord>($"v4/seasons/{id}/extended", cancellationToken);
        }

        /// <summary>
        /// Returns season type records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Season type records.</returns>
        public async Task<List<SeasonType>?> GetSeasonTypesAsync(CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<SeasonType>>($"v4/seasons/types", cancellationToken);
        }

        /// <summary>
        /// Returns season translation record.
        /// </summary>
        /// <param name="id">Id of the season.</param>
        /// <param name="language">Lanuage of the translations.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Translation record.</returns>
        public async Task<Translation?> GetSeasonTranslationAsync(long id, Languages language, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<Translation>($"v4/seasons/{id}/translations/{language.Value()}", cancellationToken);
        }
    }
}
