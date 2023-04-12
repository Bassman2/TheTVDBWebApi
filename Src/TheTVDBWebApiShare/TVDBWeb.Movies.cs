namespace TheTVDBWebApi
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
            return await GetNumAsync("v4/movies", cancellationToken);
        }

        /// <summary>
        /// Returns list of movie base records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of movie base records.</returns>
        public IAsyncEnumerable<MovieBaseRecord> GetMoviesAsync(CancellationToken cancellationToken = default)
        {
            return GetLongListAsync<MovieBaseRecord>("v4/movies", cancellationToken);
        }
        
        /// <summary>
        /// Returns movie base record.
        /// </summary>
        /// <param name="id">Id of the movie to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Movie base record.</returns>
        public async Task<MovieBaseRecord> GetMovieAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<MovieBaseRecord>($"v4/movies/{id}", cancellationToken);
        }

        /// <summary>
        /// Returns movie extended record.
        /// </summary>
        /// <param name="id">Id of the movie to get.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Movie extended record.</returns>
        public async Task<MovieExtendedRecord> GetMovieExtendedAsync(long id, Meta? meta = null, bool? shortVersion = null, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<MovieExtendedRecord>($"v4/movies/{id}/extended{BuildParam(meta, shortVersion)}", cancellationToken);
        }

        /// <summary>
        /// Search movies based on filter parameters.
        /// </summary>
        /// <param name="filter">Search filter.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of movie base records.</returns>
        public IAsyncEnumerable<MovieBaseRecord> GetMoviesFilterAsync(MoviesFilter filter, CancellationToken cancellationToken = default)
        {
            return GetLongListAsync<MovieBaseRecord>($"v4/movies/filter?{filter.Parameter}", cancellationToken);
        }

        /// <summary>
        /// Returns movie base record search by slug.
        /// </summary>
        /// <param name="slug">Slug to search for.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Movie base record.</returns>
        public async Task<MovieBaseRecord> GetMovieSlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<MovieBaseRecord>($"v4/movies/slug/{slug}", cancellationToken);
        }

        /// <summary>
        /// Returns movie translation record.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <param name="language">Lanuage of the translations.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Translation record.</returns>
        public async Task<Translation> GetMovieTranslationAsync(long id, Languages language, CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<Translation>($"v4/movies/{id}/translations/{language.Value()}", cancellationToken);
        }

        /// <summary>
        /// Returns list of status records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>List of status records.</returns>
        public async Task<List<Status>> GetMovieStatusesAsync(CancellationToken cancellationToken = default)
        {
            return await GetDataAsync<List<Status>>($"v4/movies/statuses", cancellationToken);
        }
    }
}
