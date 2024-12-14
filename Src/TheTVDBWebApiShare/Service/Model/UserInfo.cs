namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// User info record.
/// </summary>
public class UserInfo
{
    /// <summary>
    /// Id of the user.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Language of the user.
    /// </summary>
    [JsonPropertyName("language")]
    public Languages Language { get; set; }

    /// <summary>
    /// Name of the user.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Type of the user.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; } 
}
