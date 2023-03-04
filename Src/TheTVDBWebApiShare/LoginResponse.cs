namespace TheTVDBWebApiShare
{
    public class LoginResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
