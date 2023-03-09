namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns list of language records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of language records.</returns>
        public async Task<List<Language>> GetLanguagesAsync(CancellationToken cancellationToken = default)
        {
            Response<List<Language>> resp = await GetAsync<List<Language>>("v4/languages", cancellationToken);
            return resp.Data;
        }
    }
}
