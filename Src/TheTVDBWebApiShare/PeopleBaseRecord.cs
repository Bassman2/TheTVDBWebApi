namespace TheTVDBWebApi
{
    /// <summary>
    /// Base people record.
    /// </summary>
    public class PeopleBaseRecord
    {
        /// <summary>
        /// Id of the people.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the people.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Image url of the people
        /// </summary>
        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("score")]
        public long Score { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<Languages>? NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<Languages>? OverviewTranslations { get; set; }

        [JsonPropertyName("aliases")]
        public List<Alias>? Aliases { get; set; }        

        [JsonPropertyName("lastUpdated")]
        public DateTime? LastUpdated { get; set; }
    }
}
