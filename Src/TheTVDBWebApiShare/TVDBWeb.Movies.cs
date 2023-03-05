using System.Runtime.CompilerServices;

namespace TheTVDBWebApiShare
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns number of movie base records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Number of movie base records.</returns>
        public async Task<long> GetMoviesNumAsync(CancellationToken cancellationToken = default)
        {
            Response<List<MovieBaseRecord>> resp = await GetAsync<List<MovieBaseRecord>>("v4/movies?page=0", cancellationToken);
            return resp.Links.TotalItems;
        }

        /// <summary>
        /// Returns list of movie base records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of movie base records.</returns>
        public async IAsyncEnumerable<MovieBaseRecord> GetMoviesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string requestUri = "v4/movies?page=0";
            while (!string.IsNullOrEmpty(requestUri)) 
            {
                Response<List<MovieBaseRecord>> resp = await GetAsync<List<MovieBaseRecord>>(requestUri, cancellationToken);
                foreach (MovieBaseRecord movie in resp.Data)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }
                    yield return movie;
                }
                requestUri = resp.Links.Next;
            }  
        }

        /// <summary>
        /// Returns movie base record.
        /// </summary>
        /// <param name="id">Id of the movie to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Movie base record.</returns>
        public async Task<MovieBaseRecord> GetMovieAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<MovieBaseRecord> resp = await GetAsync<MovieBaseRecord>($"v4/movies/{id}", cancellationToken);
            return resp.Data;
            
        }

        /// <summary>
        /// Returns movie base record.
        /// </summary>
        /// <param name="id">Id of the movie to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Movie base record.</returns>
        public async Task<MovieExtendedRecord> GetMovieExtendedRecordAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<MovieExtendedRecord> resp = await GetAsync<MovieExtendedRecord>($"v4/movies/{id}/extended", cancellationToken);
            return resp.Data;

        }

        //public async Task<MoviesResponse> MoviesAsync(int pageNumber)
        //{
        //    MoviesResponse resp = await client.GetFromJsonAsync<MoviesResponse>($"movies?page={pageNumber}");
        //    return resp;
        //}

        public async Task<List<Status>> GetMovieStatusesAsync(CancellationToken cancellationToken = default)
        {
            Response<List<Status>> resp = await GetAsync<List<Status>>($"v4/movies/statuses", cancellationToken);
            return resp.Data;
        }
    }
}
