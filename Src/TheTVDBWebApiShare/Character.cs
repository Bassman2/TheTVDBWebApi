namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Character record.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// An alias model, which can be associated with a series, season, movie, person, or list.
        /// </summary>
        [JsonPropertyName("aliases")]
        public List<Alias> Aliases { get; set; }

        [JsonPropertyName("episode")]
        public RecordInfo Episode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("episodeId")]
        public int? EpisodeId { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("isFeatured")]
        public bool IsFeatured { get; set; }

        [JsonPropertyName("movieId")]
        public int MovieId { get; set; }

        [JsonPropertyName("movie")]
        public RecordInfo Movie { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }

        [JsonPropertyName("peopleId")]
        public int PeopleId { get; set; }

        [JsonPropertyName("personImgURL")]
        public string PersonImgURL { get; set; }

        [JsonPropertyName("peopleType")]
        public string PeopleType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("seriesId")]
        public int? SeriesId { get; set; }

        [JsonPropertyName("series")]
        public RecordInfo Series { get; set; }

        [JsonPropertyName("sort")]
        public long Sort { get; set; }

        [JsonPropertyName("tagOptions")]
        public List<TagOption> TagOptions { get; set; }

        [JsonPropertyName("type")]
        public long Type { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("personName")]
        public string PersonName { get; set; }
    }
}
