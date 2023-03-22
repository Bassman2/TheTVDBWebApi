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
        public int Id { get; set; }

        [JsonPropertyName("seriesId")]
        public long SeriesId { get; set; }

        [JsonPropertyName("type")]
        public SeasonType Type { get; set; }

        /// <summary>
        /// Name of the season.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("number")]
        public long Number { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }

        /// <summary>
        /// Uri of a season image.
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("imageType")]
        public int ImageType { get; set; }

        [JsonPropertyName("companies")]
        public Companies Companies { get; set; }

        /// <summary>
        /// Last updated date.
        /// </summary>
        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }
        
        /// <summary>
        /// Year of the season.
        /// </summary>
        /// <remarks>Not exists for extended Record </remarks>
        [JsonPropertyName("year")]
        public string Year { get; set; }
    }
}
