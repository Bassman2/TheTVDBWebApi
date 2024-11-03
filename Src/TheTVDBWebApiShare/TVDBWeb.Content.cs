namespace TheTVDBWebApi
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns list content rating records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of content rating records.</returns>
        public async Task<List<ContentRating>?> GetContentRatingsAsync(CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<List<ContentRating>>("v4/content/ratings", cancellationToken);
        }
    }
}
