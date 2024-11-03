namespace TheTVDBWebApi
{
    /// <summary>
    /// Character record.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null</remarks>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("peopleId")]
        public long PeopleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("seriesId")]
        public long? SeriesId { get; set; }

        [JsonPropertyName("series")]
        public RecordInfo? Series { get; set; }

        [JsonPropertyName("movie")]
        public RecordInfo? Movie { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("movieId")]
        public long? MovieId { get; set; }

        [JsonPropertyName("episode")]
        public RecordInfo? Episode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("episodeId")]
        public long? EpisodeId { get; set; }

        [JsonPropertyName("type")]
        public long Type { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("sort")]
        public long Sort { get; set; }

        [JsonPropertyName("isFeatured")]
        public bool IsFeatured { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string>? NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string>? OverviewTranslations { get; set; }

        /// <summary>
        /// An alias model, which can be associated with a series, season, movie, person, or list.
        /// </summary>
        [JsonPropertyName("aliases")]
        public List<Alias>? Aliases { get; set; }

        [JsonPropertyName("peopleType")]
        public string? PeopleType { get; set; }

        [JsonPropertyName("personName")]
        public string? PersonName { get; set; }

        [JsonPropertyName("tagOptions")]
        public List<TagOption>? TagOptions { get; set; }

        [JsonPropertyName("personImgURL")]
        public string? PersonImgURL { get; set; }
    }
}
