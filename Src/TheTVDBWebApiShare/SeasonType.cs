namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Season type record.
    /// </summary>
    public class SeasonType
    {

        [JsonPropertyName("alternateName")]
        public string AlternateName { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
