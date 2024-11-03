namespace TheTVDBWebApi
{
    /// <summary>
    /// Remote id record.
    /// </summary>
    public class RemoteID
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public long Type { get; set; }

        [JsonPropertyName("sourceName")]
        public string? SourceName { get; set; }
    }
}
