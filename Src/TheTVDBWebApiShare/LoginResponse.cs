using System.Text.Json.Serialization;

namespace TheTVDBWebApiShare
{
    public class LoginResponse
    {
        [JsonPropertyName("data")]
        public LoginResponseData Data { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
