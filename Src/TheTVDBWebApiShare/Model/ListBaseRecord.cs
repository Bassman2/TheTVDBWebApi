namespace TheTVDBWebApi
{
    /// <summary>
    /// Base list record.
    /// </summary>
    public class ListBaseRecord
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("isOfficial")]
        public bool IsOfficial { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<Languages>? NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<Languages>? OverviewTranslations { get; set; }

        /// <summary>
        /// An alias model, which can be associated with a series, season, movie, person, or list.
        /// </summary>
        [JsonPropertyName("aliases")]
        public List<Alias>? Aliases { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("imageIsFallback")]
        public bool ImageIsFallback { get; set; }

        [JsonPropertyName("remoteIds")]
        public List<RemoteID>? RemoteIds { get; set; }

        [JsonPropertyName("tags")]
        public List<TagOption>? Tags { get; set; }
    }
}
