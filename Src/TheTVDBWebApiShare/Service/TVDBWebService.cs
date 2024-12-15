namespace TheTVDBWebApi.Service;

internal class TVDBWebService(Uri host, string apikey) : JsonService(host, SourceGenerationContext.Default, new BearerAuthenticator(apikey))
{
    #region private

    protected override void TestAutentication()
    {
        try
        {
            var _ = GetStringAsync("/rest/api/2/serverInfo", default).Result;
        }
        catch (Exception ex)
        {
            throw new AuthenticationException(ex.Message, ex);
        }
    }

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
}
