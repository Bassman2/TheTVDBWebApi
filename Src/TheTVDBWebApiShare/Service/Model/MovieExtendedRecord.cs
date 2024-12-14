namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Extended movie record.
/// </summary>
public class MovieExtendedRecord : MovieBaseRecord
{
    [JsonPropertyName("trailers")]
    public List<Trailer>? Trailers { get; set; }

    [JsonPropertyName("genres")]
    public List<GenreBaseRecord>? Genres { get; set; }

    [JsonPropertyName("releases")]
    public List<Release>? Releases { get; set; }

    /// <summary>
    /// Base artwork record.
    /// </summary>
    [JsonPropertyName("artworks")]
    public List<ArtworkBaseRecord>? Artworks { get; set; }

    [JsonPropertyName("remoteIds")]
    public List<RemoteID>? RemoteIds { get; set; }

    [JsonPropertyName("characters")]
    public List<Character>? Characters { get; set; }

    [JsonPropertyName("budget")]
    public string? Budget { get; set; }

    [JsonPropertyName("boxOffice")]
    public string? BoxOffice { get; set; }

    [JsonPropertyName("boxOfficeUS")]
    public string? BoxOfficeUS { get; set; }

    [JsonPropertyName("originalCountry")]
    public string? OriginalCountry { get; set; }

    [JsonPropertyName("originalLanguage")]
    public string? OriginalLanguage { get; set; }

    [JsonPropertyName("audioLanguages")]
    public List<string>? AudioLanguages { get; set; }

    [JsonPropertyName("subtitleLanguages")]
    public List<string>? SubtitleLanguages { get; set; }

    [JsonPropertyName("studios")]
    public List<StudioBaseRecord>? Studios { get; set; }

    [JsonPropertyName("awards")]
    public List<AwardBaseRecord>? Awards { get; set; }

    [JsonPropertyName("tagOptions")]
    public List<TagOption>? TagOptions { get; set; }

    [JsonPropertyName("lists")]
    public List<ListBaseRecord>? Lists { get; set; }

    [JsonPropertyName("translations")]
    public TranslationExtended? Translations { get; set; }

    [JsonPropertyName("contentRatings")]
    public List<ContentRating>? ContentRatings { get; set; }

    [JsonPropertyName("companies")]
    public Companies? Companies { get; set; }

    [JsonPropertyName("production_countries")]
    public List<ProductionCountry>? ProductionCountries { get; set; }

    [JsonPropertyName("inspirations")]
    public List<Inspiration>? Inspirations { get; set; }

    [JsonPropertyName("spoken_languages")]
    public List<string>? SpokenLanguages { get; set; }

    [JsonPropertyName("first_release")]
    public Release? FirstRelease { get; set; }
}

