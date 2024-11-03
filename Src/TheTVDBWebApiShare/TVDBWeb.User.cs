namespace TheTVDBWebApi
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns user info.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>User info.</returns>
        public async Task<UserInfo?> GetUserInfoAsync(CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<UserInfo>("v4/user", cancellationToken);
        }

        /// <summary>
        /// Returns user info.
        /// </summary>
        /// <param name="cancellationToken">Id of the user.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>User info.</returns>
        public async Task<UserInfo?> GetUserInfoAsync(int id, CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<UserInfo>($"v4/user/{id}", cancellationToken);
        }

        /// <summary>
        /// Returns user favorites.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of user favorites.</returns>
        public async Task<Favorites?> GetUserFavoritesAsync(CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<Favorites>("v4/user/favorites", cancellationToken);
        }


        /// <summary>
        /// Creates a new user favorite
        /// </summary>
        /// <param name="favorites">Favorites record.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task SetUserFavoritesAsync(Favorites favorites, CancellationToken cancellationToken = default)
        {
            //PostAsJson Async
            //await PostAsync<Favorites, Favorites>("v4/user/favorites", favorites, cancellationToken);
            await PostAsJsonAsync<Favorites>("v4/user/favorites", favorites, cancellationToken);
        }
    }
}
