﻿namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns list of inspiration types records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of inspiration types records.</returns>
        public async Task<List<InspirationType>> GetInspirationTypesAsync(CancellationToken cancellationToken = default)
        {
            Response<List<InspirationType>> resp = await GetAsync<List<InspirationType>>("v4/inspiration/types", cancellationToken);
            return resp.Data;
        }
    }
}
