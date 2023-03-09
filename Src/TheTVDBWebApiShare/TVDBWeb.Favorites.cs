namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns user favorites.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of user favorites.</returns>
        public async Task<List<Favorites>> GetFavoritesAsync(CancellationToken cancellationToken = default)
        {
            Response<List<Favorites>> resp = await GetAsync<List<Favorites>>("v4/user/favorites", cancellationToken);
            return resp.Data;
        }


        /// <summary>
        /// Creates a new user favorite
        /// </summary>
        /// <param name="favorites">Favorites record.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task SetFavoritesAsync(FavoriteRecord favorite, CancellationToken cancellationToken = default)
        {
            await PostAsync<Favorites, FavoriteRecord>("v4/user/favorites", favorite, cancellationToken);
        }
    }
}
