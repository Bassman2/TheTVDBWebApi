namespace TheTVDBWebApi
{
    /// <summary>
    /// Entity update record.
    /// </summary>
    public class EntityUpdate
    {
        [JsonPropertyName("entityType")]
        public string? EntityType { get; set; }

        [JsonPropertyName("method")]
        public string? Method { get; set; }

        [JsonPropertyName("recordId")]
        public long RecordId { get; set; }

        [JsonPropertyName("timeStamp")]
        public long TimeStamp { get; set; }

        [JsonPropertyName("seriesId")]
        public long SeriesId { get; set; }

        [JsonPropertyName("mergeToId")]
        public long? MergeToId { get; set; }

        [JsonPropertyName("mergeToEntityType")]
        public long? MergeToEntityType { get; set; }

    }
}
