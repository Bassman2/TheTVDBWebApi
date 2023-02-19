using System.Text.Json.Serialization;

namespace TheTVDBWebApiShare
{
    public class MoviesResponse
    {
        [JsonPropertyName("data")]
        public List<LoginResponseData> Data { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("links")]
        public Links Links { get; set; }
    }
}
