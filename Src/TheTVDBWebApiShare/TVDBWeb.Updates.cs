namespace TheTVDBWebApi
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
        public async Task<long> GetUpdatesNumAsync(DateTime since, UpdateType? type, UpdateAction? action, CancellationToken cancellationToken = default)
        {
            StringBuilder param = new();
            param.Append($"&since={ConvertToUnixTime(since)}");           
            if (type.HasValue)
            {
                param.Append($"&type={type.ToString().ToLower()}");
            }
            if (action.HasValue)
            {
                param.Append($"&action={action.ToString().ToLower()}");
            }
            string par = param.ToString().TrimStart('&');
            return await GetNumAsync($"v4/updates?{par}", cancellationToken);
        }

        /// <summary>
        /// Returns updated entities. methodInt indicates a created record (1), an updated record (2), or a deleted record (3). If a record is deleted because it was a duplicate of another record, the target record's information is provided in mergeToType and mergeToId.
        /// </summary>
        /// <param name="since">Updates sice.</param>
        /// <param name="type">Type of Updates.</param>
        /// <param name="action">Update actions.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of movie base records.</returns>
        public IAsyncEnumerable<MovieBaseRecord> GetUpdatesAsync(DateTime since, UpdateType? type, UpdateAction? action, CancellationToken cancellationToken = default)
        {
            StringBuilder param = new();
            param.Append($"&since={ConvertToUnixTime(since)}");
            if (type.HasValue)
            {
                param.Append($"&type={type.ToString().ToLower()}");
            }
            if (action.HasValue)
            {
                param.Append($"&action={action.ToString().ToLower()}");
            }
            string par = param.ToString().TrimStart('&');
            return GetYieldAsync<MovieBaseRecord>($"v4/updates?{par}", cancellationToken);
        }
    }
}
