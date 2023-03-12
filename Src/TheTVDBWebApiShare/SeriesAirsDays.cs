namespace TheTVDBWebApiShare
{
    /// <summary>
    /// A series airs day record.
    /// </summary>
    public class SeriesAirsDays
    {
        [JsonPropertyName("friday")]
        public bool Friday { get; set; }

        [JsonPropertyName("monday")]
        public bool Monday { get; set; }

        [JsonPropertyName("saturday")]
        public bool Saturday { get; set; }

        [JsonPropertyName("sunday")]
        public bool Sunday { get; set; }

        [JsonPropertyName("thursday")]
        public bool Thursday { get; set; }

        [JsonPropertyName("tuesday")]
        public bool Tuesday { get; set; }

        [JsonPropertyName("wednesday")]
        public bool Wednesday { get; set; }
    }
}
