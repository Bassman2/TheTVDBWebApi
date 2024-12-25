namespace TheTVDBWebApi.Service;

internal class TVDBWebService(Uri host, string apikey) : JsonService(host, SourceGenerationContext.Default, new BearerAuthenticator(apikey))
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
        return (await GetFromJsonAsync<Response>(requestUri, cancellationToken))?.Links?.TotalItems ?? 0;
    }

    private async IAsyncEnumerable<TRes> GetYieldAsync<TRes>(string requestUri, [EnumeratorCancellation] CancellationToken cancellationToken, [CallerMemberName] string memberName = "") where TRes : class
    {
        while (!string.IsNullOrEmpty(requestUri))
        {
            Debug.WriteLine($"GetYieldAsync {typeof(TRes).Name} {requestUri}");
            Response<List<TRes>>? resp = await GetFromJsonAsync<Response<List<TRes>>>(requestUri, cancellationToken, memberName);
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

    //private static int ConvertToUnixTime(DateTime dateTime)
    //{
    //    DateTime UnixTimeStart = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    //    return (int)(dateTime - UnixTimeStart).TotalSeconds;
    //}

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
}
