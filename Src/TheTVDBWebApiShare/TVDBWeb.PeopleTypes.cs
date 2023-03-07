namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
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
