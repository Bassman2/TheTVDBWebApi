namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Base people record.
    /// </summary>
    public class PeopleBaseRecord
    {
        [JsonPropertyName("aliases")]
        public List<Alias> Aliases { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// Name of the artwork status.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }

        [JsonPropertyName("score")]
        public long Score { get; set; }
    }
}
