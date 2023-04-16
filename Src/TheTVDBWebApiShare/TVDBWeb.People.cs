namespace TheTVDBWebApi
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns number of people base records with the basic attributes.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Number of people.</returns>
        public async Task<long> GetPeoplesNumAsync(CancellationToken cancellationToken = default)
        {
            return await GetNumAsync("v4/people", cancellationToken);
        }

        /// <summary>
        /// Returns a list of people base records with the basic attributes.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of people base records with the basic attributes.</returns>
        public IAsyncEnumerable<PeopleBaseRecord> GetPeopleAsync(CancellationToken cancellationToken = default)
        {
            return GetYieldAsync<PeopleBaseRecord>("v4/people", cancellationToken);
        }

        /// <summary>
        /// Returns people base record.
        /// </summary>
        /// <param name="id">Id of the people base record to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>People base record.</returns>
        public async Task<PeopleBaseRecord> GetPeopleAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<PeopleBaseRecord>($"v4/people/{id}", cancellationToken);
        }

        /// <summary>
        /// Returns movie extended record.
        /// </summary>
        /// <param name="id">Id of the movie to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>People extended record.</returns>
        public async Task<PeopleExtendedRecord> GetPeopleExtendedAsync(long id, Meta? meta = null, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<PeopleExtendedRecord>($"v4/people/{id}/extended{BuildParam(meta)}", cancellationToken);
        }

        /// <summary>
        /// Returns people translation record.
        /// </summary>
        /// <param name="id">Id of the people.</param>
        /// <param name="language">Lanuage of the translations.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Translation record.</returns>
        public async Task<Translation> GetPeopleTranslationAsync(long Id, Languages language, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<Translation>($"v4/people/{Id}/translations/{language.Value()}", cancellationToken);
        }

        /// <summary>
        /// Returns a list of people type records
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of people type records</returns>
        public async Task<List<PeopleType>> GetPeopleTypesAsync(CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<PeopleType>>($"v4/people/types", cancellationToken);
        }
    }
}
