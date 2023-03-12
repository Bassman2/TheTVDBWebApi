namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns user info.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>User info.</returns>
        public async Task<UserInfo> GetUserInfoAsync(CancellationToken cancellationToken = default)
        {
            Response<UserInfo> resp = await GetAsync<UserInfo>("v4/user", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns user info.
        /// </summary>
        /// <param name="cancellationToken">Id of the user.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>User info.</returns>
        public async Task<UserInfo> GetUserInfoAsync(int id, CancellationToken cancellationToken = default)
        {
            Response<UserInfo> resp = await GetAsync<UserInfo>($"v4/user/{id}", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns user favorites.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of user favorites.</returns>
        public async Task<List<Favorites>> GetUserFavoritesAsync(CancellationToken cancellationToken = default)
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
        public async Task SetUserFavoritesAsync(FavoriteRecord favorite, CancellationToken cancellationToken = default)
        {
            await PostAsync<Favorites, FavoriteRecord>("v4/user/favorites", favorite, cancellationToken);
        }
    }
}
