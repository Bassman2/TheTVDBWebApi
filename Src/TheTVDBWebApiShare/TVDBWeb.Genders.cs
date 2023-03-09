namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns list of gender records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of gender records.</returns>
        public async Task<List<Gender>> GetGendersAsync(CancellationToken cancellationToken = default)
        {
            Response<List<Gender>> resp = await GetAsync<List<Gender>>("v4/genders", cancellationToken);
            return resp.Data;
        }
    }
}
