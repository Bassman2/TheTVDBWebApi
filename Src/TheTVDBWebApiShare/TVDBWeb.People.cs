namespace TheTVDBWebApiShare
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
            Response<List<PeopleBaseRecord>> resp = await GetAsync<List<PeopleBaseRecord>>("v4/people?page=0", cancellationToken);
            return resp.Links.TotalItems;
        }

        /// <summary>
        /// Returns a list of people base records with the basic attributes.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of people base records with the basic attributes.</returns>
        public async IAsyncEnumerable<PeopleBaseRecord> GetPeoplesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string requestUri = "v4/people?page=0";
            while (!string.IsNullOrEmpty(requestUri))
            {
                Response<List<PeopleBaseRecord>> resp = await GetAsync<List<PeopleBaseRecord>>(requestUri, cancellationToken);
                foreach (var item in resp.Data)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }
                    yield return item;
                }
                requestUri = resp.Links.Next;
            }
        }

        /// <summary>
        /// Returns people base record.
        /// </summary>
        /// <param name="id">Id of the people base record to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>People base record.</returns>
        public async Task<PeopleBaseRecord> GetPeopleAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<PeopleBaseRecord> resp = await GetAsync<PeopleBaseRecord>($"v4/people/{id}", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns movie extended record.
        /// </summary>
        /// <param name="id">Id of the movie to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>People extended record.</returns>
        public async Task<PeopleExtendedRecord> GetPeopleExtendedAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<PeopleExtendedRecord> resp = await GetAsync<PeopleExtendedRecord>($"v4/people/{id}/extended", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns people translation record.
        /// </summary>
        /// <param name="id">Id of the people.</param>
        /// <param name="language">Lanuage of the translations.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Translation record.</returns>
        public async Task<Translation> GetPeopleTranslationAsync(string Id, string language, CancellationToken cancellationToken = default)
        {
            Response<Translation> resp = await GetAsync<Translation>($"v4/people/{Id}/translations/{language}", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns a list of people type records
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of people type records</returns>
        public async Task<List<PeopleType>> GetPeopleTypesAsync(CancellationToken cancellationToken = default)
        {
            Response<List<PeopleType>> resp = await GetAsync<List<PeopleType>>($"v4/people/types", cancellationToken);
            return resp.Data;
        }
    }
}
