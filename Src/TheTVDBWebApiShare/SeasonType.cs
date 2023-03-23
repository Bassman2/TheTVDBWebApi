namespace TheTVDBWebApi
{
    /// <summary>
    /// Season type record.
    /// </summary>
    public class SeasonType
    {
        /// <summary>
        /// Id of the season type.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the season type.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of the season type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Alternate name of the season type.
        /// </summary>
        [JsonPropertyName("alternateName")]
        public string AlternateName { get; set; }

        public override string ToString()
        {
            return $"#{Id} Name:{Name} Type:{Type} AlternateName:{AlternateName}";
        }
    }
}
