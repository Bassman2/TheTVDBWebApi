namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns a list of award base records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of award base records.</returns>
        public async Task<List<AwardBaseRecord>> GetAwardsAsync(CancellationToken cancellationToken = default)
        {
            Response<List<AwardBaseRecord>> resp = await GetAsync<List<AwardBaseRecord>>("v4/awards", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns a single award base record.
        /// </summary>
        /// <param name="id">Id of the award base record.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Single award base record.</returns>
        public async Task<AwardBaseRecord> GetAwardAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<AwardBaseRecord> resp = await GetAsync<AwardBaseRecord>($"v4/awards/{id}", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns a single award extended record.
        /// </summary>
        /// <param name="id">Id of the award extended record.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Single award extended record.</returns>
        public async Task<AwardExtendedRecord> GetAwardExtendedAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<AwardExtendedRecord> resp = await GetAsync<AwardExtendedRecord>($"v4/awards/{id}/extended", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns a single award category base record.
        /// </summary>
        /// <param name="id">Id of the award category base record.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Single award category base record.</returns>
        public async Task<AwardCategoryBaseRecord> GetAwardCategoryAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<AwardCategoryBaseRecord> resp = await GetAsync<AwardCategoryBaseRecord>($"v4/awards/categories/{id}", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns a single award category extended record.
        /// </summary>
        /// <param name="id">Id of the award category extended record.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Single award category extended record.</returns>
        public async Task<AwardCategoryExtendedRecord> GetAwardCategoryExtendedAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<AwardCategoryExtendedRecord> resp = await GetAsync<AwardCategoryExtendedRecord>($"v4/awards/categories/{id}/extended", cancellationToken);
            return resp.Data;
        }
    }
}
