namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// artwork status record
/// </summary>
internal class ArtworkStatusModel
{
    /// <summary>
    /// Identifier of the artwork status.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Name of the artwork status.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
