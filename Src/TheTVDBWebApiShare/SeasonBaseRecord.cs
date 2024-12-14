namespace TheTVDBWebApi
{
    /// <summary>
    /// Season base record.
    /// </summary>
    public class SeasonBaseRecord
    {
        /// <summary>
        /// Id of the season.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("seriesId")]
        public long SeriesId { get; set; }

        [JsonPropertyName("type")]
        public SeasonType? Type { get; set; }

        /// <summary>
        /// Name of the season.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("number")]
        public long Number { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<Languages>? NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<Languages>? OverviewTranslations { get; set; }

        /// <summary>
        /// Uri of a season image.
        /// </summary>
        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("imageType")]
        public int ImageType { get; set; }

        [JsonPropertyName("companies")]
        public Companies? Companies { get; set; }

        /// <summary>
        /// Last updated date.
        /// </summary>
        [JsonPropertyName("lastUpdated")]
        public DateTime? LastUpdated { get; set; }
        
        /// <summary>
        /// Year of the season.
        /// </summary>
        /// <remarks>Not exists for extended Record </remarks>
        [JsonPropertyName("year")]
        public string? Year { get; set; }
    }
}
