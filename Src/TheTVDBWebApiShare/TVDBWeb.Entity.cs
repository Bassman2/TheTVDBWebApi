namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns the active entity types.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of the active entity types.</returns>
        public async Task<List<EntityType>> GetEntityTypesAsync(CancellationToken cancellationToken = default)
        {
            Response<List<EntityType>> resp = await GetAsync<List<EntityType>>("v4//entities", cancellationToken);
            return resp.Data;
        }
    }
}
