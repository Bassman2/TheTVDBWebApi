namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Extended list record.
    /// </summary>
    public class ListExtendedRecord
    {
        /// <summary>
        /// An alias model, which can be associated with a series, season, movie, person, or list.
        /// </summary>
        [JsonPropertyName("aliases")]
        public List<Alias> Aliases { get; set; }

        [JsonPropertyName("entities")]
        public List<Entity> Entities { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("imageIsFallback")]
        public bool ImageIsFallback { get; set; }

        [JsonPropertyName("isOfficial")]
        public bool IsOfficial { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
