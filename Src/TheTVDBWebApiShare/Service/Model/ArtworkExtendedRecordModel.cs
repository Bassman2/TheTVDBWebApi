namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Extended artwork record.
/// </summary>
internal class ArtworkExtendedRecordModel : ArtworkBaseRecordModel
{
    [JsonPropertyName("thumbnailWidth")]
    public long ThumbnailWidth { get; set; }

    [JsonPropertyName("thumbnailHeight")]
    public long ThumbnailHeight { get; set; }

    [JsonPropertyName("updatedAt")]
    public long UpdatedAt { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Artwork for a movie only.</remarks>
    [JsonPropertyName("movieId")]
    public long MovieId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Artwork for a series only.</remarks>
    [JsonPropertyName("seriesId")]
    public long SeriesId { get; set; }

    [JsonPropertyName("episodeId")]
    public long EpisodeId { get; set; }

    [JsonPropertyName("networkId")]
    public long NetworkId { get; set; }

    [JsonPropertyName("peopleId")]
    public long PeopleId { get; set; }

    [JsonPropertyName("seasonId")]
    public long SeasonId { get; set; }

    [JsonPropertyName("seriesPeopleId")]
    public long SeriesPeopleId { get; set; }

    [JsonPropertyName("status")]
    public ArtworkStatus? Status { get; set; }

    [JsonPropertyName("tagOptions")]
    public IEnumerable<TagOptionModel>? TagOptions { get; set; }
}
