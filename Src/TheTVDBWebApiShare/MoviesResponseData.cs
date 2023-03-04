namespace TheTVDBWebApiShare
{
    public class MoviesResponseData
    {
        [JsonPropertyName("aliases")]
        public List<Alias> Aliases { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }

        [JsonPropertyName("score")]
        public long Score { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("runtime")]
        public long Runtime { get; set; }

        [JsonPropertyName("year")]
        public string Year { get; set; }
    }
}
