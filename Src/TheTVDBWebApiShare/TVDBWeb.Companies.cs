namespace TheTVDBWebApi
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns number of companies.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Number of companies.</returns>
        public async Task<long> GetCompaniesNumAsync(CancellationToken cancellationToken = default)
        {
            return await GetNumAsync("v4/companies", cancellationToken);
        }

        /// <summary>
        /// Returns a list of company records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of company records.</returns>
        public IAsyncEnumerable<Company> GetCompaniesAsync(CancellationToken cancellationToken = default)
        {
            return GetLongListAsync<Company>("v4/companies", cancellationToken);
        }

        /// <summary>
        /// Returns all company type records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of company type records.</returns>
        public async Task<List<CompanyType>> GetCompanyTypesAsync(CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<CompanyType>>("v4/companies/types", cancellationToken);
        }

        /// <summary>
        /// Returns a company record.
        /// </summary>
        /// <param name="id">Id of the character base record.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Single company record.</returns>
        public async Task<Company> GetCompanyAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<Company>($"v4/companies/{id}", cancellationToken);
        }
    }
}
