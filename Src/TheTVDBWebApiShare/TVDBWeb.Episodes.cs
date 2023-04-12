namespace TheTVDBWebApi
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns number of episodes base records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Number of episodes base records.</returns>
        public async Task<long> GetEpisodesNumAsync(CancellationToken cancellationToken = default)
        {
            return await GetNumAsync("v4/episodes", cancellationToken);
        }

        /// <summary>
        /// Returns list of episodes base records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of episodes base records.</returns>
        public IAsyncEnumerable<EpisodeBaseRecord> GetEpisodesAsync(CancellationToken cancellationToken = default)
        {
            return GetLongListAsync<EpisodeBaseRecord>("v4/episodes", cancellationToken);
        }

        /// <summary>
        /// Returns episode base record.
        /// </summary>
        /// <param name="id">Id of the episode to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Episode base record.</returns>
        public async Task<EpisodeBaseRecord> GetEpisodeAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<EpisodeBaseRecord>($"v4/episodes/{id}", cancellationToken);
        }

        /// <summary>
        /// Returns episode extended record.
        /// </summary>
        /// <param name="id">Id of the episode to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Movie extended record.</returns>
        public async Task<EpisodeExtendedRecord> GetEpisodeExtendedAsync(long id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<EpisodeExtendedRecord>($"v4/episodes/{id}/extended{BuildParam(meta)}", cancellationToken);
        }

        /// <summary>
        /// Returns episode translation record.
        /// </summary>
        /// <param name="id">Id of the episode to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Episode translation record.</returns>
        public async Task<Translation> GetEpisodeTranslationAsync(long id, Languages language, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<Translation>($"v4/episodes/{id}/translations/{language.Value()}", cancellationToken);
        }
    }
}
