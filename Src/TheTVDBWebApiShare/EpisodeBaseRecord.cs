namespace TheTVDBWebApi
{
    /// <summary>
    /// Base episode record.
    /// </summary>
    public class EpisodeBaseRecord
    {
        /// <summary>
        /// Id of the episode.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("seriesId")]
        public long SeriesId { get; set; }

        /// <summary>
        /// Name of the episode.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("aired")]
        public DateOnly? Aired { get; set; }

        /// <summary>
        /// Runtime of the episode.
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("runtime")]
        public int? Runtime { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }

        /// <summary>
        /// Uri of a episode image.
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        /// <summary>
        /// Type of the image.
        /// </summary>
        /// <remarks>Can be null if no image.</remarks>
        [JsonPropertyName("imageType")]
        public int? ImageType { get; set; }

        [JsonPropertyName("isMovie")]
        public long IsMovie { get; set; }

        [JsonPropertyName("seasons")]
        public List<SeasonBaseRecord> Seasons { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("number")]
        public int? Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("seasonNumber")]
        public int? SeasonNumber { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("finaleType")]
        public FinaleType? FinaleType { get; set; }

        /// <summary>
        /// Year of the episode.
        /// </summary>
        [JsonPropertyName("year")]
        public string Year { get; set; }

        
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /*

        [JsonPropertyName("airsAfterSeason")]
        public int AirsAfterSeason { get; set; }

        [JsonPropertyName("airsBeforeEpisode")]
        public int AirsBeforeEpisode { get; set; }

        [JsonPropertyName("airsBeforeSeason")]
        public int AirsBeforeSeason { get; set; }        

        [JsonPropertyName("linkedMovie")]
        public int LinkedMovie { get; set; }

        [JsonPropertyName("seasonName")]
        public string SeasonName { get; set; }
        */
    }
}
