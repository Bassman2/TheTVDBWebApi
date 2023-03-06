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
        /// <returns>Movie extended record.</returns>
        public async Task<MovieExtendedRecord> GetMovieExtendedAsync(long id, CancellationToken cancellationToken = default)
        {
            Response<MovieExtendedRecord> resp = await GetAsync<MovieExtendedRecord>($"v4/movies/{id}/extended", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Search movies based on filter parameters.
        /// </summary>
        /// <param name="filter">Search filter.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of movie base records.</returns>
        public async IAsyncEnumerable<MovieBaseRecord> GetMoviesFilterAsync(MoviesFilter filter, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string requestUri = $"v4/movies/filter?{filter.Parameter}";
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
        /// Returns movie base record search by slug.
        /// </summary>
        /// <param name="slug">Slug to search for.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Movie base record.</returns>
        public async Task<MovieBaseRecord> GetMovieSlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            Response<MovieBaseRecord> resp = await GetAsync<MovieBaseRecord>($"v4/movies/slug/{slug}", cancellationToken);
            return resp.Data;
        }

        /// <summary>
        /// Returns movie translation record.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <param name="language">Lanuage of the translations.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Translation record.</returns>
        public async Task<Translation> GetMovieTranslationAsync(string movieId, string language, CancellationToken cancellationToken = default)
        {
            Response<Translation> resp = await GetAsync<Translation>($"v4/movies/{movieId}/translations/{language}", cancellationToken);
            return resp.Data;
        }
    }
}
