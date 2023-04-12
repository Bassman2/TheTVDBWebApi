namespace TheTVDBWebApi
{
    /// <summary>
    /// User favorites record.
    /// </summary>
    public class Favorites
    {
        [JsonPropertyName("series")]
        public List<long> Series { get; set; }

        [JsonPropertyName("movies")]
        public List<long> Movies { get; set; }

        [JsonPropertyName("episodes")]
        public List<long> Episodes { get; set; }

        [JsonPropertyName("artwork")]
        public List<long> Artwork { get; set; }

        [JsonPropertyName("people")]
        public List<long> People { get; set; }

        [JsonPropertyName("lists")]
        public List<long> Lists { get; set; }
    }
}
