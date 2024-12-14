namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Links for next, previous and current record.
/// </summary>
public class Links
{
    /// <summary>
    /// Uri of previous record.
    /// </summary>
    [JsonPropertyName("prev")]
    public string? Prev { get; set; }

    /// <summary>
    /// Uri of current record.
    /// </summary>
    [JsonPropertyName("selfn")]
    public string? Self { get; set; }

    /// <summary>
    /// Uri of next record.
    /// </summary>
    [JsonPropertyName("next")]
    public string? Next { get; set; }

    /// <summary>
    /// Total numbers of items.
    /// </summary>
    [JsonPropertyName("total_items")]
    public long TotalItems { get; set; }

    /// <summary>
    /// Size of the current page.
    /// </summary>
    [JsonPropertyName("page_size")]
    public long PageSize { get; set; }
}
