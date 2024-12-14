namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// The base record for a series.
/// </summary>
/// <remarks>
/// All series airs time like firstAired, lastAired, nextAired, etc. are in US EST for US series, and for all non-US series, the time of the show’s country capital or most populous city. For streaming services, is the official release time. See https://support.thetvdb.com/kb/faq.php?id=29.
/// </remarks>
public class SeriesBaseRecord
{
    /// <summary>
    /// Id of the series.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Name of the series.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Slug of the series.
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// Uri of a series image.
    /// </summary>
    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("nameTranslations")]
    public List<Languages>? NameTranslations { get; set; }

    [JsonPropertyName("overviewTranslations")]
    public List<Languages>? OverviewTranslations { get; set; }

    /// <summary>
    /// An alias model, which can be associated with a series, season, movie, person, or list.
    /// </summary>
    [JsonPropertyName("aliases")]
    public List<Alias>? Aliases { get; set; }

    /// <summary>
    /// Date of first aired or null if unknown.
    /// </summary>
    /// <remarks>Can be null.</remarks>
    [JsonPropertyName("firstAired")]
    public DateOnly? FirstAired { get; set; }

    /// <summary>
    /// Date of last aired or null if unknown.
    /// </summary>
    /// <remarks>Can be null.</remarks>
    [JsonPropertyName("lastAired")]
    public DateOnly? LastAired { get; set; }

    /// <summary>
    /// Date of next aired or null if unknown.
    /// </summary>
    /// <remarks>Can be null.</remarks>
    [JsonPropertyName("nextAired")]
    public DateOnly? NextAired { get; set; }

    /// <summary>
    /// Score of the series.
    /// </summary>
    [JsonPropertyName("score")]
    public double Score { get; set; }

    /// <summary>
    /// Status of the serie.
    /// </summary>
    [JsonPropertyName("status")]
    public Status? Status { get; set; }

    /// <summary>
    /// Original country of the series.
    /// </summary>
    [JsonPropertyName("originalCountry")]
    public string? OriginalCountry { get; set; }

    /// <summary>
    /// Original language of the series.
    /// </summary>
    [JsonPropertyName("originalLanguage")]
    public string? OriginalLanguage { get; set; }

    [JsonPropertyName("defaultSeasonType")]
    public long DefaultSeasonType { get; set; }

    [JsonPropertyName("isOrderRandomized")]
    public bool IsOrderRandomized { get; set; }

    /// <summary>
    /// Date of last updated.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Average runtime of the series.
    /// </summary>
    /// <remarks>Can be null.</remarks>
    [JsonPropertyName("averageRuntime")]
    public int? AverageRuntime { get; set; }

    [JsonPropertyName("episodes")]
    public List<EpisodeBaseRecord>? Episodes { get; set; }

    [JsonPropertyName("overview")]
    public string? Overview { get; set; }

    /// <summary>
    /// Year of the serie.
    /// </summary>
    [JsonPropertyName("year")]
    public string? Year { get; set; }

    // in class description but not in API
    //[JsonPropertyName("country")]
    //public string Country { get; set; }
}
