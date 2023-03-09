namespace TheTVDBWebApiShare
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
            Response<List<EpisodeBaseRecord>> resp = await GetAsync<List<EpisodeBaseRecord>>("v4/episodes?page=0", cancellationToken);
            return resp.Links.TotalItems;
        }

        /// <summary>
        /// Returns list of episodes base records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of episodes base records.</returns>
        public async IAsyncEnumerable<EpisodeBaseRecord> GetEpisodesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string requestUri = "v4/episodes?page=0";
            while (!string.IsNullOrEmpty(requestUri))
            {
                Response<List<EpisodeBaseRecord>> resp = await GetAsync<List<EpisodeBaseRecord>>(requestUri, cancellationToken);
                foreach (EpisodeBaseRecord item in resp.Data)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }
                    yield return item;
                }
                requestUri = resp.Links.Next;
            }
        }

        /// <summary>
        /// Returns episode base record.
        /// </summary>
        /// <param name="id">Id of the episode to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Episode base record.</returns>
        public async Task<EpisodeBaseRecord> GetEpisodeAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<EpisodeBaseRecord> resp = await GetAsync<EpisodeBaseRecord>($"v4/episodes/{id}", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns episode extended record.
        /// </summary>
        /// <param name="id">Id of the episode to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Movie extended record.</returns>
        public async Task<EpisodeExtendedRecord> GetEpisodeExtendedAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<EpisodeExtendedRecord> resp = await GetAsync<EpisodeExtendedRecord>($"v4/episodes/{id}/extended", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns episode translation record.
        /// </summary>
        /// <param name="id">Id of the episode to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Episode translation record.</returns>
        public async Task<Translation> GetEpisodeTranslationAsync(long id, string language, CancellationToken cancellationToken = default)
        {
            Response<Translation> resp = await GetAsync<Translation>($"v4/episodes/{id}/translations/{language}", cancellationToken);
            return resp.Data;
        }
    }
}
