namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Studio record.
/// </summary>
public class StudioBaseRecord
{
    /// <summary>
    /// Id of the studio.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Name of the studio.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Id of a parent studio or null if not.
    /// </summary>
    /// <remarks>Can be null.</remarks>
    [JsonPropertyName("parentStudio")]
    public long? ParentStudio { get; set; }
}
