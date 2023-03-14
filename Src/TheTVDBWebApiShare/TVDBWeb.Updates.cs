namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns number of updates.
        /// </summary>
        /// <param name="since">Updates sice.</param>
        /// <param name="type">Type of Updates.</param>
        /// <param name="action">Update actions.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Number of updates.</returns>
        public async Task<long> GetUpdatesNumAsync(int since, UpdateType type, UpdateAction action, CancellationToken cancellationToken = default)
        {
            return await GetNumAsync("v4//updates?since={since}&type={type}&action={action}", cancellationToken);
        }

        /// <summary>
        /// Returns updated entities. methodInt indicates a created record (1), an updated record (2), or a deleted record (3). If a record is deleted because it was a duplicate of another record, the target record's information is provided in mergeToType and mergeToId.
        /// </summary>
        /// <param name="since">Updates sice.</param>
        /// <param name="type">Type of Updates.</param>
        /// <param name="action">Update actions.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of movie base records.</returns>
        public async IAsyncEnumerable<MovieBaseRecord> GetUpdatesAsync(int since, UpdateType type, UpdateAction action, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string requestUri = "v4/updates?since={since}&type={type}&action={action}&page=0";
            while (!string.IsNullOrEmpty(requestUri))
            {
                Response<List<MovieBaseRecord>> resp = await GetAsync<List<MovieBaseRecord>>(requestUri, cancellationToken);
                foreach (MovieBaseRecord item in resp.Data)
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
    }
}
