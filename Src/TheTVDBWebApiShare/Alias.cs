using System.Text.Json.Serialization;

namespace TheTVDBWebApiShare
{
    public class Alias
    {
        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
