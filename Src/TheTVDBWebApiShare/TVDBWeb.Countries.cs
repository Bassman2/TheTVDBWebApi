namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns list of country records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of country records.</returns>
        public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken = default)
        {
            Response<List<Country>> resp = await GetAsync<List<Country>>("v4/countries", cancellationToken);
            return resp.Data;
        }
    }
}
