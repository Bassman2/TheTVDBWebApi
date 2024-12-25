namespace TheTVDBWebApi;

/// <summary>
/// The TVDB Web API class
/// </summary>
/// <remarks>https://thetvdb.github.io/v4-api</remarks>
/// <remarks>https://thetvdb.com/dashboard/account/apikey</remarks>
/// <remarks>
/// Constructor.
/// </remarks>
public sealed partial class TVDBWeb : IDisposable
{
    //private const string host = "https://api4.thetvdb.com";
    private TVDBWebService? service;

    public TVDBWeb(string storeKey)
    {
        var key = WebServiceClient.Store.KeyStore.Key(storeKey)!;
        string host = key.Host!;
        string token = key.Token!;
        service = new(new Uri(host), token);
    }

    public TVDBWeb(Uri uri, string apiKey)
    {
        service = new(uri, apiKey);
    }

    public void Dispose()
    {
        if (this.service != null)
        {
            this.service.Dispose();
            this.service = null;
        }
        GC.SuppressFinalize(this);
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

    #region Artwork

    /// <summary>
    /// Returns a single artwork base record.
    /// </summary>
    /// <param name="id">Id of the artwork base record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single artwork base record.</returns>
    public async Task<ArtworkBaseRecord?> GetArtworkAsync(long id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetArtworkAsync(id, cancellationToken);
        return res.CastModel<ArtworkBaseRecord>();
    }

    /// <summary>
    /// Returns a single artwork extended record.
    /// </summary>
    /// <param name="id">Id of the artwork extended record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single artwork extended record.</returns>
    public async Task<ArtworkExtendedRecord?> GetArtworkExtendedAsync(long id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetArtworkExtendedAsync(id, cancellationToken);
        return res.CastModel<ArtworkExtendedRecord>();
    }

    /// <summary>
    /// Returns a list of artworkStatus records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of artworkStatus records.</returns>
    public async Task<IEnumerable<ArtworkStatus>?> GetArtworkStatusesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetArtworkStatusesAsync(cancellationToken);
        return res.CastModel<ArtworkStatus>();
    }

    /// <summary>
    /// Returns a list of artworkType records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of artworkType records.</returns>
    public async Task<IEnumerable<ArtworkType>?> GetArtworkTypesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetArtworkTypesAsync(cancellationToken);
        return res.CastModel<ArtworkType>();
    }

    #endregion

    #region Awards

    /// <summary>
    /// Returns a list of award base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of award base records.</returns>
    public async Task<IEnumerable<AwardBaseRecord>?> GetAwardsAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetAwardsAsync(cancellationToken);
        return res.CastModel<AwardBaseRecord>();
    }

    /// <summary>
    /// Returns a single award base record.
    /// </summary>
    /// <param name="id">Id of the award base record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single award base record.</returns>
    public async Task<AwardBaseRecord?> GetAwardAsync(long id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetAwardAsync(id, cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a single award extended record.
    /// </summary>
    /// <param name="id">Id of the award extended record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single award extended record.</returns>
    public async Task<AwardExtendedRecord?> GetAwardExtendedAsync(long id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetAwardExtendedAsync(id, cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a single award category base record.
    /// </summary>
    /// <param name="id">Id of the award category base record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single award category base record.</returns>
    public async Task<AwardCategoryBaseRecord?> GetAwardCategoryAsync(long id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetAwardCategoryAsync(id, cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a single award category extended record.
    /// </summary>
    /// <param name="id">Id of the award category extended record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single award category extended record.</returns>
    public async Task<AwardCategoryExtendedRecord?> GetAwardCategoryExtendedAsync(long id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetAwardCategoryExtendedAsync(id, cancellationToken);
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
    public async Task<Character?> GetCharacterAsync(long id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetCharacterAsync(id, cancellationToken);
        return res;
    }

    #endregion

    #region Companies

    /// <summary>
    /// Returns number of companies.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Number of companies.</returns>
    public async Task<long> GetCompaniesNumAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetCompaniesNumAsync(cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a list of company records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of company records.</returns>
    public IAsyncEnumerable<Company> GetCompaniesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = service.GetCompaniesAsync(cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns all company type records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of company type records.</returns>
    public async Task<List<CompanyType>?> GetCompanyTypesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetCompanyTypesAsync(cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a company record.
    /// </summary>
    /// <param name="id">Id of the character base record.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Single company record.</returns>
    public async Task<Company?> GetCompanyAsync(long id, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetCompanyAsync(id, cancellationToken);
        return res;
    }

    #endregion

    #region Content

    /// <summary>
    /// Returns list content rating records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of content rating records.</returns>
    public async Task<List<ContentRating>?> GetContentRatingsAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetContentRatingsAsync(cancellationToken);
        return res;
    }

    #endregion

    #region Countries

    /// <summary>
    /// Returns list of country records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of country records.</returns>
    public async Task<List<Country>?> GetCountriesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetCountriesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetEntitiesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetEpisodesNumAsync(cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of episodes base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of episodes base records.</returns>
    public IAsyncEnumerable<EpisodeBaseRecord> GetEpisodesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = service.GetEpisodesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetEpisodeAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetEpisodeExtendedAsync(id, meta, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetEpisodeTranslationAsync(id, language, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetGendersAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetGenresAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetGenreAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetInspirationTypesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetLanguagesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetListsNumAsync(cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of episodes base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of episodes base records.</returns>
    public IAsyncEnumerable<ListBaseRecord> GetListsAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = service.GetListsAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetListAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetListBySlugAsync(slug, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetListExtendedAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetListTranslationAsync(id, language, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetMoviesNumAsync(cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of movie base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of movie base records.</returns>
    public IAsyncEnumerable<MovieBaseRecord> GetMoviesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = service.GetMoviesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetMovieAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetMovieExtendedAsync(id, meta, shortVersion, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = service.GetMoviesFilterAsync(filter, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetMovieSlugAsync(slug, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetMovieTranslationAsync(id, language, cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of status records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of status records.</returns>
    public async Task<List<Status>?> GetMovieStatusesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetMovieStatusesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetPeoplesNumAsync(cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a list of people base records with the basic attributes.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of people base records with the basic attributes.</returns>
    public IAsyncEnumerable<PeopleBaseRecord> GetPeopleAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = service.GetPeopleAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetPeopleAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetPeopleExtendedAsync(id, meta, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetPeopleTranslationAsync(Id, language, cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a list of people type records
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of people type records</returns>
    public async Task<List<PeopleType>?> GetPeopleTypesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetPeopleTypesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = service.GetSearchAsync(filter, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSearchAsync(remoteId, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeasonsNumAsync(cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of seasons base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of seasons base records.</returns>
    public IAsyncEnumerable<SeasonBaseRecord> GetSeasonsAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = service.GetSeasonsAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeasonAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeasonExtendedAsync(id, cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns season type records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Season type records.</returns>
    public async Task<List<SeasonType>?> GetSeasonTypesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeasonTypesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeasonTranslationAsync(id, language, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeriesNumAsync(cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns list of series base records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of series base records.</returns>
    public IAsyncEnumerable<SeriesBaseRecord> GetSeriesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = service.GetSeriesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeriesAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeriesArtworkAsync(id, language, type, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeriesNextAiredAsync(id, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeriesExtendedAsync(id, meta, shortVersion, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeriesEpisodesAsync(id, seasonType, season, episodeNumber, airDate, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeriesEpisodesAsync(id, seasonType, language, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = service.GetSeriesFilterAsync(filter, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeriesSlugAsync(slug, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeriesTranslationAsync(id, language, cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns a list of status records.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of status records</returns>
    public async Task<List<Status>?> GetSeriesStatusesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSeriesStatusesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetSourceTypesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetUpdatesNumAsync(since, type, action, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = service.GetUpdatesAsync(since, type, action, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetUserInfoAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetUserInfoAsync(id, cancellationToken);
        return res;
    }

    /// <summary>
    /// Returns user favorites.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>List of user favorites.</returns>
    public async Task<Favorites?> GetUserFavoritesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetUserFavoritesAsync(cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.SetUserFavoritesAsync(favorites, cancellationToken);
    }

    #endregion
}
