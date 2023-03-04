namespace TheTVDBWebApiShare
{
    public class Links
    {
        [JsonPropertyName("prev")]
        public string Prev { get; set; }

        [JsonPropertyName("selfn")]
        public string Self { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("total_items")]
        public long TotalItems { get; set; }

        [JsonPropertyName("page_size")]
        public long PageSize { get; set; }
    }
}
