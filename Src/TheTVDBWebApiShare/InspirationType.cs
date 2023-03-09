namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Movie inspiration type record
    /// </summary>
    public class InspirationType
    {
        /// <summary>
        /// Id of the inspiration type.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the inspiration type.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("reference_name")]
        public string ReferenceName { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
