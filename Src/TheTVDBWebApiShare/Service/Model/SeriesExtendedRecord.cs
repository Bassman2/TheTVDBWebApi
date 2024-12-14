namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// The extended record for a series. 
/// </summary>
/// <Remark>All series airs time like firstAired, lastAired, nextAired, etc. are in US EST for US series, and for all non-US series, the time of the show’s country capital or most populous city. For streaming services, is the official release time. See https://support.thetvdb.com/kb/faq.php?id=29.</Remark>
public class SeriesExtendedRecord : SeriesBaseRecord
{
    [JsonPropertyName("artworks")]
    public List<ArtworkExtendedRecord>? Artworks { get; set; }

    [JsonPropertyName("companies")]
    public List<Company>? Companies { get; set; }

    [JsonPropertyName("originalNetwork")]
    public Company? OriginalNetwork { get; set; }

    [JsonPropertyName("latestNetwork")]
    public Company? LatestNetwork { get; set; }

    [JsonPropertyName("genres")]
    public List<GenreBaseRecord>? Genres { get; set; }

    [JsonPropertyName("trailers")]
    public List<Trailer>? Trailers { get; set; }

    [JsonPropertyName("lists")]
    public List<object>? Lists { get; set; }

    [JsonPropertyName("remoteIds")]
    public List<RemoteID>? RemoteIds { get; set; }

    [JsonPropertyName("characters")]
    public List<Character>? Characters { get; set; }

    [JsonPropertyName("airsDays")]
    public SeriesAirsDays? AirsDays { get; set; }

    [JsonPropertyName("airsTime")]
    public string? AirsTime { get; set; }

    [JsonPropertyName("seasons")]
    public List<SeasonBaseRecord>? Seasons { get; set; }

    [JsonPropertyName("translations")]
    public TranslationExtended? Translations { get; set; }

    [JsonPropertyName("tags")]
    public List<TagOption>? Tags { get; set; }

    [JsonPropertyName("contentRatings")]
    public List<ContentRating>? ContentRatings { get; set; }

    [JsonPropertyName("seasonTypes")]
    public List<SeasonType>? SeasonTypes { get; set; }


    // in class description but not in API
    //[JsonPropertyName("abbreviation")]
    //public string Abbreviation { get; set; }

    //[JsonPropertyName("country")]
    //public string Country { get; set; }  
}
