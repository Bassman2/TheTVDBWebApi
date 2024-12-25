using WebServiceClient;

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

        var res = service.GetAwardExtendedAsync(id, cancellationToken);
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
}
