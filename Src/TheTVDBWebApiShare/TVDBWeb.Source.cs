namespace TheTVDBWebApi
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns list of source type records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of source type records</returns>
        public async Task<List<SourceType>> GetSourceTypesAsync(CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<SourceType>>($"v4/sources/types", cancellationToken);
        }
    }
}
