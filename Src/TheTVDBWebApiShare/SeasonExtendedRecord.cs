namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Extended season record.
    /// </summary>
    public class SeasonExtendedRecord
    {
        [JsonPropertyName("artwork")]
        public List<ArtworkBaseRecord> Artwork { get; set; }

        [JsonPropertyName("companies")]
        public List<Companies> Companies { get; set; }

        [JsonPropertyName("episodes")]
        public List<EpisodeBaseRecord> Episodes { get; set; }

        /// <summary>
        /// Id of the season.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Uri of a season image.
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("imageType")]
        public int ImageType { get; set; }

        /// <summary>
        /// Last updated date.
        /// </summary>
        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// Name of the season.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("number")]
        public long Number { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }
        
        [JsonPropertyName("seriesId")]
        public long SeriesId { get; set; }

        [JsonPropertyName("trailers")]
        public List<Trailer> Trailers { get; set; }

        [JsonPropertyName("type")]
        public SeasonType Type { get; set; }

        [JsonPropertyName("tagOptions")]
        public List<TagOption> TagOptions { get; set; }

        [JsonPropertyName("translations")]
        public List<Translation> Translations { get; set; }

        /// <summary>
        /// Year of the season.
        /// </summary>
        [JsonPropertyName("year")]
        public string Year { get; set; }
    }
}
