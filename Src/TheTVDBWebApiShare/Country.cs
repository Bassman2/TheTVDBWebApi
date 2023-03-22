namespace TheTVDBWebApi
{
    /// <summary>
    /// Country record.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Id of the country record.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the country  record.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of the country  record.
        /// </summary>
        [JsonPropertyName("shortCode")]
        public string ShortCode { get; set; }
    }
}
