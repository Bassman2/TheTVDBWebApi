namespace TheTVDBWebApi
{
    /// <summary>
    /// Extended episode record.
    /// </summary>
    public class EpisodeExtendedRecord
    {
        [JsonPropertyName("aired")]
        public string Aired { get; set; }

        [JsonPropertyName("airsAfterSeason")]
        public int AirsAfterSeason { get; set; }

        [JsonPropertyName("airsBeforeEpisode")]
        public int AirsBeforeEpisode { get; set; }

        [JsonPropertyName("airsBeforeSeason")]
        public int AirsBeforeSeason { get; set; }

        [JsonPropertyName("awards")]
        public List<AwardBaseRecord> Awards { get; set; }

        [JsonPropertyName("characters")]
        public List<Character> Characters { get; set; }

        [JsonPropertyName("companies")]
        public List<Company> Companies { get; set; }

        [JsonPropertyName("contentRatings")]
        public List<ContentRating> ContentRatings { get; set; }

        [JsonPropertyName("finaleType")]
        public FinaleType? FinaleType { get; set; }

        /// <summary>
        /// Id of the episode.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Uri of a episode image.
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("imageType")]
        public int ImageType { get; set; }

        [JsonPropertyName("isMovie")]
        public long IsMovie { get; set; }

        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("linkedMovie")]
        public int LinkedMovie { get; set; }

        /// <summary>
        /// Name of the episode.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("networks")]
        public List<Company> Networks { get; set; }

        [JsonPropertyName("nominations")]
        public List<AwardNomineeBaseRecord> Nominations { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }

        [JsonPropertyName("productionCode")]
        public string productionCode { get; set; }

        /// <summary>
        /// Runtime of the episode.
        /// </summary>
        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }

        [JsonPropertyName("seasonNumber")]
        public int SeasonNumber { get; set; }

        [JsonPropertyName("seasons")]
        public List<SeasonBaseRecord> Seasons { get; set; }

        [JsonPropertyName("seriesId")]
        public long SeriesId { get; set; }

        [JsonPropertyName("studios")]
        public List<Company> Studios { get; set; }

        [JsonPropertyName("tagOptions")]
        public List<TagOption> TagOptions { get; set; }

        [JsonPropertyName("trailers")]
        public List<Trailer> Trailers { get; set; }

        [JsonPropertyName("translations")]
        public List<TranslationExtended> Translations { get; set; }

        /// <summary>
        /// Year of the episode.
        /// </summary>
        [JsonPropertyName("year")]
        public string Year { get; set; }
    }
}
