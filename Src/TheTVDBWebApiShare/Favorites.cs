namespace TheTVDBWebApi
{
    /// <summary>
    /// User favorites record.
    /// </summary>
    public class Favorites
    {
        [JsonPropertyName("series")]
        public List<int> Series { get; set; }

        [JsonPropertyName("movies")]
        public List<int> Movies { get; set; }

        [JsonPropertyName("episodes")]
        public List<int> Episodes { get; set; }

        [JsonPropertyName("artwork")]
        public List<int> Artwork { get; set; }

        [JsonPropertyName("people")]
        public List<int> People { get; set; }

        [JsonPropertyName("lists")]
        public List<int> Lists { get; set; }
    }
}
