namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Gender record.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Identifier of gender record.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the gender record.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
