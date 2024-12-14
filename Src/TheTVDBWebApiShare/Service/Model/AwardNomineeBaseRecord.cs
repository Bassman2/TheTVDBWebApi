namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Base award nominee record.
/// </summary>
public class AwardNomineeBaseRecord
{
    /// <summary>
    /// Id of the award nominee.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("year")]
    public string? Year { get; set; }

    [JsonPropertyName("details")]
    public string? Details { get; set; }

    [JsonPropertyName("isWinner")]
    public bool IsWinner { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    /// Name of the award nominee.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("series")]
    public SeriesBaseRecord? Series { get; set; }

    [JsonPropertyName("movie")]
    public MovieBaseRecord? Movie { get; set; }

    [JsonPropertyName("episode")]
    public EpisodeBaseRecord? Episode { get; set; }

    [JsonPropertyName("character")]
    public Character? Character { get; set; }
}
