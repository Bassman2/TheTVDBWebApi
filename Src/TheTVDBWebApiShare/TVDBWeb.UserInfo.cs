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
            Response<UserInfo> resp = await GetAsync<UserInfo>($"v4/user", cancellationToken);
            return resp.Data;
        }
    }
}
