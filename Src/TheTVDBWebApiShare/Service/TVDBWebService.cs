namespace TheTVDBWebApi.Service;

internal class TVDBWebService(Uri host, IAuthenticator? authenticator, string appName)
    : JsonService(host, authenticator, appName, SourceGenerationContext.Default)
{
    #region private

    protected override string? AuthenticationTestUrl => "/rest/api/2/serverInfo";

    //protected override async Task ErrorHandlingAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    //{
    //    //if (response.Content is JsonContent)
    //    //{
    //    //    var error = await ReadFromJsonAsync<ErrorModel>(response, cancellationToken);
    //    //    throw new WebServiceException(error?.ToString(), response.RequestMessage?.RequestUri, response.StatusCode, response.ReasonPhrase, memberName);
    //    //}
    //    throw new WebServiceException("", response.RequestMessage?.RequestUri, response.StatusCode, response.ReasonPhrase, memberName);
    //}

    private async Task<long> GetNumAsync(string requestUri, CancellationToken cancellationToken, [CallerMemberName] string memberName = "")
    {
        return (await GetFromJsonAsync<ResponseModel>(requestUri, cancellationToken))?.Links?.TotalItems ?? 0;
    }

    private async IAsyncEnumerable<TRes> GetYieldAsync<TRes>(string requestUri, [EnumeratorCancellation] CancellationToken cancellationToken, [CallerMemberName] string memberName = "") where TRes : class
    {
        while (!string.IsNullOrEmpty(requestUri))
        {
            Debug.WriteLine($"GetYieldAsync {typeof(TRes).Name} {requestUri}");
            ResponseModel<List<TRes>>? resp = await GetFromJsonAsync<ResponseModel<List<TRes>>>(requestUri, cancellationToken, memberName);
            foreach (TRes item in resp!.Data!)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    yield break;
                }
                yield return item;
            }
            requestUri = resp.Links!.Next!;
        }
    }

    private static string BuildParam(Meta? meta, bool? shortVersion = null)
    {
        string parameter = string.Empty;
        if (meta.HasValue)
        {
            parameter += (parameter.Contains('?') ? "&meta=" : "?meta=") + meta.Value.ToString().ToLower();
        }
        if (shortVersion.HasValue)
        {
            parameter += (parameter.Contains('?') ? "&short=" : "?short=") + (shortVersion.Value ? "true" : "false");
        }
        return parameter;
    }

    private static string BuildParam(MetaSeries? meta, bool? shortVersion = null)
    {
        string parameter = string.Empty;
        if (meta.HasValue)
        {
            parameter += (parameter.Contains('?') ? "&meta=" : "?meta=") + meta.Value.ToString().ToLower();
        }
        if (shortVersion.HasValue)
        {
            parameter += (parameter.Contains('?') ? "&short=" : "?short=") + (shortVersion.Value ? "true" : "false");
        }
        return parameter;
    }

    private static int ConvertToUnixTime(DateTime dateTime)
    {
        DateTime UnixTimeStart = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return (int)(dateTime - UnixTimeStart).TotalSeconds;
    }
    
    #endregion

    #region Artwork

    public async Task<ArtworkBaseRecordModel?> GetArtworkAsync(long id, CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<ArtworkBaseRecordModel>($"v4/artwork/{id}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a single artwork extended record.
    /// </summary>
    /// <param name="id">Id of the artwork extended record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single artwork extended record.</returns>
    public async Task<ArtworkExtendedRecordModel?> GetArtworkExtendedAsync(long id, CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<ArtworkExtendedRecordModel>($"v4/artwork/{id}/extended", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a list of artworkStatus records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of artworkStatus records.</returns>
    public async Task<IEnumerable<ArtworkStatusModel>?> GetArtworkStatusesAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<IEnumerable<ArtworkStatusModel>>($"v4/artwork/statuses", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a list of artworkType records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of artworkType records.</returns>
    public async Task<IEnumerable<ArtworkTypeModel>?> GetArtworkTypesAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<IEnumerable<ArtworkTypeModel>>($"v4/artwork/types", cancellationToken);
        return res;
    }

    #endregion

    #region Awards

    /// <summary>
    /// Returns a list of award base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of award base records.</returns>
    public async Task<List<AwardBaseRecord>?> GetAwardsAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<List<AwardBaseRecord>>("v4/awards", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a single award base record.
    /// </summary>
    /// <param name="id">Id of the award base record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single award base record.</returns>
    public async Task<AwardBaseRecord?> GetAwardAsync(long id, CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<AwardBaseRecord>($"v4/awards/{id}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a single award extended record.
    /// </summary>
    /// <param name="id">Id of the award extended record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single award extended record.</returns>
    public async Task<AwardExtendedRecord?> GetAwardExtendedAsync(long id, CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<AwardExtendedRecord>($"v4/awards/{id}/extended", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a single award category base record.
    /// </summary>
    /// <param name="id">Id of the award category base record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single award category base record.</returns>
    public async Task<AwardCategoryBaseRecord?> GetAwardCategoryAsync(long id, CancellationToken cancellationToken)
    {

        var res = await GetFromJsonAsync<AwardCategoryBaseRecord>($"v4/awards/categories/{id}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a single award category extended record.
    /// </summary>
    /// <param name="id">Id of the award category extended record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single award category extended record.</returns>
    public async Task<AwardCategoryExtendedRecord?> GetAwardCategoryExtendedAsync(long id, CancellationToken cancellationToken)
    {

        var res = await GetFromJsonAsync<AwardCategoryExtendedRecord>($"v4/awards/categories/{id}/extended", cancellationToken);
        return res;
    }

    #endregion

    #region Characters

    /// <summary>
    /// Returns character base record.
    /// </summary>
    /// <param name="id">Id of the character base record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Character base record.</returns>
    public async Task<Character?> GetCharacterAsync(long id, CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<Character>($"v4/characters/{id}", cancellationToken);
        return res;
    }

    #endregion

    #region Companies

    /// <summary>
    /// Returns number of companies.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Number of companies.</returns>
    public async Task<long> GetCompaniesNumAsync(CancellationToken cancellationToken)
    {
        var res = await GetNumAsync("v4/companies", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a list of company records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of company records.</returns>
    public IAsyncEnumerable<Company> GetCompaniesAsync(CancellationToken cancellationToken)
    {
        var res = GetYieldAsync<Company>("v4/companies", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns all company type records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of company type records.</returns>
    public async Task<List<CompanyType>?> GetCompanyTypesAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<List<CompanyType>>("v4/companies/types", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a company record.
    /// </summary>
    /// <param name="id">Id of the character base record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single company record.</returns>
    public async Task<Company?> GetCompanyAsync(long id, CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<Company>($"v4/companies/{id}", cancellationToken);
        return res;
    }

    #endregion

    #region Content

    /// <summary>
    /// Returns list content rating records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of content rating records.</returns>
    public async Task<List<ContentRating>?> GetContentRatingsAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<List<ContentRating>>("v4/content/ratings", cancellationToken);
        return res;
    }

    #endregion

    #region Countries

    /// <summary>
    /// Returns list of country records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of country records.</returns>
    public async Task<List<Country>?> GetCountriesAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<List<Country>>("v4/countries", cancellationToken);
        return res;
    }

    #endregion

    #region Entities

    /// <summary>
    /// Returns the active entity types.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of the active entity types.</returns>
    public async Task<List<EntityType>?> GetEntitiesAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<EntityType>>("v4/entities", cancellationToken);
        return res;
    }

    #endregion

    #region Episodes

    /// <summary>
    /// Returns number of episodes base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Number of episodes base records.</returns>
    public async Task<long> GetEpisodesNumAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetNumAsync("v4/episodes", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of episodes base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of episodes base records.</returns>
    public IAsyncEnumerable<EpisodeBaseRecord> GetEpisodesAsync(CancellationToken cancellationToken = default)
    {
        var res = GetYieldAsync<EpisodeBaseRecord>("v4/episodes", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns episode base record.
    /// </summary>
    /// <param name="id">Id of the episode to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Episode base record.</returns>
    public async Task<EpisodeBaseRecord?> GetEpisodeAsync(long id, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<EpisodeBaseRecord>($"v4/episodes/{id}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns episode extended record.
    /// </summary>
    /// <param name="id">Id of the episode to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Movie extended record.</returns>
    public async Task<EpisodeExtendedRecord?> GetEpisodeExtendedAsync(long id, Meta? meta = null, CancellationToken cancellationToken = default)
    {
        var req = CombineUrl($"v4/episodes/{id}/extended", ("meta", meta));
        var res = await GetFromJsonAsync<EpisodeExtendedRecord>(req, cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns episode translation record.
    /// </summary>
    /// <param name="id">Id of the episode to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Episode translation record.</returns>
    public async Task<Translation?> GetEpisodeTranslationAsync(long id, Languages language, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<Translation>($"v4/episodes/{id}/translations/{language.Value()}", cancellationToken);
        return res;
    }

    #endregion

    #region Genders

    /// <summary>
    /// Returns list of gender records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of gender records.</returns>
    public async Task<List<Gender>?> GetGendersAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<Gender>>("v4/genders", cancellationToken);
        return res;
    }

    #endregion

    #region Genres

    /// <summary>
    /// Returns list of genre records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of genre records.</returns>
    public async Task<List<GenreBaseRecord>?> GetGenresAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<GenreBaseRecord>>("v4/genres", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns genre record.
    /// </summary>
    /// <param name="id">Id of the episode to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Genre record.</returns>
    public async Task<GenreBaseRecord?> GetGenreAsync(long id, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<GenreBaseRecord>($"v4/genres/{id}", cancellationToken);
        return res;
    }

    #endregion

    #region Inspiration

    /// <summary>
    /// Returns list of inspiration types records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of inspiration types records.</returns>
    public async Task<List<InspirationType>?> GetInspirationTypesAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<InspirationType>>("v4/inspiration/types", cancellationToken);
        return res;
    }

    #endregion

    #region Languages

    /// <summary>
    /// Returns list of language records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of language records.</returns>
    public async Task<List<Language>?> GetLanguagesAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<Language>>("v4/languages", cancellationToken);
        return res;
    }

    #endregion

    #region Lists

    /// <summary>
    /// Returns number of episodes base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Number of episodes base records.</returns>
    public async Task<long> GetListsNumAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetNumAsync("v4/lists", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of episodes base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of episodes base records.</returns>
    public IAsyncEnumerable<ListBaseRecord> GetListsAsync(CancellationToken cancellationToken = default)
    {
        var res = GetYieldAsync<ListBaseRecord>("v4/lists", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns an list base record.
    /// </summary>
    /// <param name="id">Id of the list to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List base record.</returns>
    public async Task<ListBaseRecord?> GetListAsync(long id, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<ListBaseRecord>($"v4/lists/{id}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns an list base record search by slug.
    /// </summary>
    /// <param name="slug">Slug of the list to get. For lists Slug is identically to the Url property.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List base record.</returns>
    public async Task<ListBaseRecord?> GetListBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<ListBaseRecord>($"v4/lists/slug/{slug}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns an list extended record.
    /// </summary>
    /// <param name="id">Id of the list to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List extended record.</returns>
    public async Task<ListExtendedRecord?> GetListExtendedAsync(long id, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<ListExtendedRecord>($"v4/lists/{id}/extended", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list translation record.
    /// </summary>
    /// <param name="id">Id of the list to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List translation record.</returns>
    public async Task<List<Translation>?> GetListTranslationAsync(long id, string language, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<Translation>>($"v4/lists/{id}/translations/{language}", cancellationToken);
        return res;
    }

    #endregion

    #region Movies

    /// <summary>
    /// Returns number of movie base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Number of movie base records.</returns>
    public async Task<long> GetMoviesNumAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetNumAsync("v4/movies", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of movie base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of movie base records.</returns>
    public IAsyncEnumerable<MovieBaseRecord> GetMoviesAsync(CancellationToken cancellationToken = default)
    {
        var res = GetYieldAsync<MovieBaseRecord>("v4/movies", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns movie base record.
    /// </summary>
    /// <param name="id">Id of the movie to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Movie base record.</returns>
    public async Task<MovieBaseRecord?> GetMovieAsync(long id, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<MovieBaseRecord>($"v4/movies/{id}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns movie extended record.
    /// </summary>
    /// <param name="id">Id of the movie to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Movie extended record.</returns>
    public async Task<MovieExtendedRecord?> GetMovieExtendedAsync(long id, Meta? meta = null, bool? shortVersion = null, CancellationToken cancellationToken = default)
    {
        var req = CombineUrl($"v4/movies/{id}/extended", ("meta", meta), ("short", shortVersion));
        var res = await GetFromJsonAsync<MovieExtendedRecord>(req, cancellationToken);
        return res;
    }

    /// <summary>
    /// Search movies based on filter parameters.
    /// </summary>
    /// <param name="filter">Search filter.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of movie base records.</returns>
    public IAsyncEnumerable<MovieBaseRecord> GetMoviesFilterAsync(MoviesFilter filter, CancellationToken cancellationToken = default)
    {
        var res = GetYieldAsync<MovieBaseRecord>($"v4/movies/filter?{filter.Parameter}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns movie base record search by slug.
    /// </summary>
    /// <param name="slug">Slug to search for.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Movie base record.</returns>
    public async Task<MovieBaseRecord?> GetMovieSlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<MovieBaseRecord>($"v4/movies/slug/{slug}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns movie translation record.
    /// </summary>
    /// <param name="movieId">Id of the movie.</param>
    /// <param name="language">Lanuage of the translations.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Translation record.</returns>
    public async Task<Translation?> GetMovieTranslationAsync(long id, Languages language, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<Translation>($"v4/movies/{id}/translations/{language.Value()}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of status records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of status records.</returns>
    public async Task<List<Status>?> GetMovieStatusesAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<Status>>($"v4/movies/statuses", cancellationToken);
        return res;
    }

    #endregion

    #region Peoples

    /// <summary>
    /// Returns number of people base records with the basic attributes.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Number of people.</returns>
    public async Task<long> GetPeoplesNumAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetNumAsync("v4/people", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a list of people base records with the basic attributes.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of people base records with the basic attributes.</returns>
    public IAsyncEnumerable<PeopleBaseRecord> GetPeopleAsync(CancellationToken cancellationToken = default)
    {
        var res = GetYieldAsync<PeopleBaseRecord>("v4/people", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns people base record.
    /// </summary>
    /// <param name="id">Id of the people base record to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>People base record.</returns>
    public async Task<PeopleBaseRecord?> GetPeopleAsync(long id, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<PeopleBaseRecord>($"v4/people/{id}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns movie extended record.
    /// </summary>
    /// <param name="id">Id of the movie to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>People extended record.</returns>
    public async Task<PeopleExtendedRecord?> GetPeopleExtendedAsync(long id, Meta? meta = null, CancellationToken cancellationToken = default)
    {
        var req = CombineUrl($"v4/people/{id}/extended", ("meta", meta));
        var res = await GetFromJsonAsync<PeopleExtendedRecord>(req, cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns people translation record.
    /// </summary>
    /// <param name="id">Id of the people.</param>
    /// <param name="language">Lanuage of the translations.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Translation record.</returns>
    public async Task<Translation?> GetPeopleTranslationAsync(long Id, Languages language, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<Translation>($"v4/people/{Id}/translations/{language.Value()}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a list of people type records
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of people type records</returns>
    public async Task<List<PeopleType>?> GetPeopleTypesAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<PeopleType>>($"v4/people/types", cancellationToken);
        return res;
    }

    #endregion

    #region Search

    /// <summary>
    /// Our search index includes series, movies, people, and companies. Search is limited to 5k results max.
    /// </summary>
    /// <param name="filter">Search filter.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Search result.</returns>
    public IAsyncEnumerable<SearchResult> GetSearchAsync(SearchFilter filter, CancellationToken cancellationToken = default)
    {
        var res = GetYieldAsync<SearchResult>($"v4/search?{filter.Parameter}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Search a series, movie, people, episode, company or season by specific remote id and returns a base record for that entity.
    /// </summary>
    /// <param name="remoteId">Search for a specific remote id.Allows searching for an IMDB or EIDR id, for example.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Search by remote reuslt is a base record for a movie, series, people, season or company search result.</returns>
    public async Task<List<SearchByRemoteIdResult>?> GetSearchAsync(string remoteId, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<SearchByRemoteIdResult>>($"v4/search/remoteid/{remoteId}", cancellationToken);
        return res;
    }

    #endregion

    #region Seasons

    /// <summary>
    /// Returns number of seasons.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Number of seasons.</returns>
    public async Task<long> GetSeasonsNumAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetNumAsync("v4/seasons", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of seasons base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of seasons base records.</returns>
    public IAsyncEnumerable<SeasonBaseRecord> GetSeasonsAsync(CancellationToken cancellationToken = default)
    {
        var res = GetYieldAsync<SeasonBaseRecord>($"v4/seasons", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns season base record.
    /// </summary>
    /// <param name="id">Id of the season to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Season base record.</returns>
    public async Task<SeasonBaseRecord?> GetSeasonAsync(long id, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<SeasonBaseRecord>($"v4/seasons/{id}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns season extended record.
    /// </summary>
    /// <param name="id">Id of the season to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Season extended record.</returns>
    public async Task<SeasonExtendedRecord?> GetSeasonExtendedAsync(long id, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<SeasonExtendedRecord>($"v4/seasons/{id}/extended", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns season type records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Season type records.</returns>
    public async Task<List<SeasonType>?> GetSeasonTypesAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<SeasonType>>($"v4/seasons/types", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns season translation record.
    /// </summary>
    /// <param name="id">Id of the season.</param>
    /// <param name="language">Lanuage of the translations.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Translation record.</returns>
    public async Task<Translation?> GetSeasonTranslationAsync(long id, Languages language, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<Translation>($"v4/seasons/{id}/translations/{language.Value()}", cancellationToken);
        return res;
    }

    #endregion

    #region Series

    /// <summary>
    /// Returns number of series.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Number of series.</returns>
    public async Task<long> GetSeriesNumAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetNumAsync("v4/series", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of series base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of series base records.</returns>
    public IAsyncEnumerable<SeriesBaseRecord> GetSeriesAsync(CancellationToken cancellationToken = default)
    {
        var res = GetYieldAsync<SeriesBaseRecord>($"v4/series", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns series base record.
    /// </summary>
    /// <param name="id">Id of the series to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Series base record.</returns>
    public async Task<SeriesBaseRecord?> GetSeriesAsync(long id, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<SeriesBaseRecord>($"v4/series/{id}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns series extended record.
    /// </summary>
    /// <param name="id">Id of the series to get.</param>
    /// <param name="language">Language</param>
    /// <param name="type">Type of the artwork.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Series extended record.</returns>
    public async Task<ArtworkBaseRecord?> GetSeriesArtworkAsync(long id, Languages language, int type, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<ArtworkBaseRecord>($"v4/series/{id}/artworks?lang={language}&type={type}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns series base record including the nextAired field.
    /// </summary>
    /// <remarks>NextAired was included in the base record endpoint but that field will deprecated in the future so developers should use the nextAired endpoint.</remarks>
    /// <param name="id">Id of the series to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Series base record.</returns>
    public async Task<SeriesBaseRecord?> GetSeriesNextAiredAsync(long id, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<SeriesBaseRecord>($"v4/series/{id}/nextAired", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns series extended record.
    /// </summary>
    /// <param name="id">Id of the series to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Series extended record.</returns>
    public async Task<SeriesExtendedRecord?> GetSeriesExtendedAsync(long id, MetaSeries? meta = null, bool? shortVersion = null, CancellationToken cancellationToken = default)
    {
        var req = CombineUrl($"v4/series/{id}/extended", ("meta", meta), ("short", shortVersion));
        var res = await GetFromJsonAsync<SeriesExtendedRecord>(req, cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns series episodes from the specified season type, default returns the episodes in the series default season type.
    /// </summary>
    /// <param name="id">Id of the series to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Episode base record.</returns>
    public async Task<SeriesEpisodes?> GetSeriesEpisodesAsync(long id, SeasonTypeEnum seasonType, long? season, int? episodeNumber, string airDate, CancellationToken cancellationToken = default)
    {
        var param = new StringBuilder();
        if (season.HasValue)
        {
            param.Append($"&season={season.Value}");
        }
        if (episodeNumber.HasValue)
        {
            param.Append($"&episodeNumber={episodeNumber.Value}");
        }
        if (!string.IsNullOrEmpty(airDate))
        {
            param.Append($"&airDate={airDate}");
        }
        string par = param.ToString().TrimStart('&');
        var res = await GetFromJsonAsync<SeriesEpisodes>($"v4/series/{id}/episodes/{seasonType.ToString().ToLower()}?{par}", cancellationToken);
        return res;

    }

    /// <summary>
    /// Returns series episodes from the specified season type, default returns the episodes in the series default season type.
    /// </summary>
    /// <param name="id">Id of the series to get.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Episode base record.</returns>
    public async Task<SeriesBaseRecord?> GetSeriesEpisodesAsync(long id, SeasonTypeEnum seasonType, Languages language, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<SeriesBaseRecord>($"v4/series/{id}/episodes/{seasonType.ToString().ToLower()}/{language}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Rearch series based on filter parameters
    /// </summary>
    /// <remarks>NextAired was included in the base record endpoint but that field will deprecated in the future so developers should use the nextAired endpoint.</remarks>
    /// <param name="filter">Filter to search for.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of series base record.</returns>
    public IAsyncEnumerable<SeriesBaseRecord> GetSeriesFilterAsync(SeriesFilter filter, CancellationToken cancellationToken = default)
    {
        var res = GetYieldAsync<SeriesBaseRecord>($"v4/series/filter?{filter.Parameter}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Series base record search by slug.
    /// </summary>
    /// <param name="slug">Slug to search for.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Series base record.</returns>
    public async Task<SeriesBaseRecord?> GetSeriesSlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<SeriesBaseRecord>($"v4/series/slug/{slug}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns series translation record.
    /// </summary>
    /// <param name="id">Id of the series.</param>
    /// <param name="language">Lanuage of the translations.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Translation record.</returns>
    public async Task<Translation?> GetSeriesTranslationAsync(long id, Languages language, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<Translation>($"v4/series/{id}/translations/{language.Value()}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a list of status records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of status records</returns>
    public async Task<List<Status>?> GetSeriesStatusesAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<Status>>($"v4/series/statuses", cancellationToken);
        return res;
    }

    #endregion

    #region Source

    /// <summary>
    /// Returns list of source type records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of source type records</returns>
    public async Task<List<SourceType>?> GetSourceTypesAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<List<SourceType>>($"v4/sources/types", cancellationToken);
        return res;
    }

    #endregion

    #region Updates

    /// <summary>
    /// Returns number of updates.
    /// </summary>
    /// <param name="since">Updates sice.</param>
    /// <param name="type">Type of Updates.</param>
    /// <param name="action">Update actions.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Number of updates.</returns>
    public async Task<long> GetUpdatesNumAsync(DateTime since, UpdateType? type, UpdateAction? action, CancellationToken cancellationToken = default)
    {
        StringBuilder param = new();
        param.Append($"&since={ConvertToUnixTime(since)}");
        if (type != null)
        {
            param.Append($"&type={type?.ToString().ToLower()}");
        }
        if (action != null)
        {
            param.Append($"&action={action?.ToString().ToLower()}");
        }
        string par = param.ToString().TrimStart('&');
        var res = await GetNumAsync($"v4/updates?{par}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns updated entities. methodInt indicates a created record (1), an updated record (2), or a deleted record (3). If a record is deleted because it was a duplicate of another record, the target record's information is provided in mergeToType and mergeToId.
    /// </summary>
    /// <param name="since">Updates sice.</param>
    /// <param name="type">Type of Updates.</param>
    /// <param name="action">Update actions.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of movie base records.</returns>
    public IAsyncEnumerable<MovieBaseRecord> GetUpdatesAsync(DateTime since, UpdateType? type, UpdateAction? action, CancellationToken cancellationToken = default)
    {
        StringBuilder param = new();
        param.Append($"&since={ConvertToUnixTime(since)}");
        if (type.HasValue)
        {
            param.Append($"&type={type.ToString()!.ToLower()}");
        }
        if (action.HasValue)
        {
            param.Append($"&action={action.ToString()!.ToLower()}");
        }
        string par = param.ToString().TrimStart('&');
        var res = GetYieldAsync<MovieBaseRecord>($"v4/updates?{par}", cancellationToken);
        return res;
    }

    #endregion

    #region User

    /// <summary>
    /// Returns user info.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>User info.</returns>
    public async Task<UserInfo?> GetUserInfoAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<UserInfo>("v4/user", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns user info.
    /// </summary>
    /// <param name="cancellationToken">Id of the user.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>User info.</returns>
    public async Task<UserInfo?> GetUserInfoAsync(int id, CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<UserInfo>($"v4/user/{id}", cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns user favorites.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of user favorites.</returns>
    public async Task<Favorites?> GetUserFavoritesAsync(CancellationToken cancellationToken = default)
    {
        var res = await GetFromJsonAsync<Favorites>("v4/user/favorites", cancellationToken);
        return res;
    }

    /// <summary>
    /// Creates a new user favorite
    /// </summary>
    /// <param name="favorites">Favorites record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task SetUserFavoritesAsync(Favorites favorites, CancellationToken cancellationToken = default)
    {
        //PostAsJson Async
        //await PostAsync<Favorites, Favorites>("v4/user/favorites", favorites, cancellationToken);
        await PostAsJsonAsync<Favorites, Favorites>("v4/user/favorites", favorites, cancellationToken);
    }

    #endregion
}
