namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns list of inspiration types records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of inspiration types records.</returns>
        public async Task<List<InspirationType>> GetInspirationTypesAsync(CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<InspirationType>>("v4/inspiration/types", cancellationToken);
        }
    }
}
