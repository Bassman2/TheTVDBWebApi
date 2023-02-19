using System.Text.Json.Serialization;

namespace TheTVDBWebApiShare
{
    public class LoginResponseData
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
