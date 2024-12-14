namespace TheTVDBWebApi.Service.Model;

/// <summary>
/// Extended episode record.
/// </summary>
public class EpisodeExtendedRecord : EpisodeBaseRecord
{
    [JsonPropertyName("productionCode")]
    public string? ProductionCode { get; set; }

    [JsonPropertyName("nominations")]
    public List<AwardNomineeBaseRecord>? Nominations { get; set; }

    [JsonPropertyName("characters")]
    public List<Character>? Characters { get; set; }

    [JsonPropertyName("contentRatings")]
    public List<ContentRating>? ContentRatings { get; set; }

    [JsonPropertyName("remoteIds")]
    public List<RemoteID>? RemoteIds { get; set; }

    [JsonPropertyName("tagOptions")]
    public List<TagOption>? TagOptions { get; set; }

    [JsonPropertyName("trailers")]
    public List<Trailer>? Trailers { get; set; }

    [JsonPropertyName("networks")]
    public List<Company>? Networks { get; set; }

    [JsonPropertyName("studios")]
    public List<Company>? Studios { get; set; }

    [JsonPropertyName("companies")]
    public List<Company>? Companies { get; set; }

    [JsonPropertyName("translations")]
    public TranslationExtended? Translations { get; set; }

    [JsonPropertyName("awards")]
    public List<AwardBaseRecord>? Awards { get; set; }



    //[JsonPropertyName("airsAfterSeason")]
    //public int AirsAfterSeason { get; set; }

    //[JsonPropertyName("airsBeforeEpisode")]
    //public int AirsBeforeEpisode { get; set; }

    //[JsonPropertyName("airsBeforeSeason")]
    //public int AirsBeforeSeason { get; set; }

    //[JsonPropertyName("linkedMovie")]
    //public int LinkedMovie { get; set; }
}
