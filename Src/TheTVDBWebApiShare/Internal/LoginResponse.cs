namespace TheTVDBWebApiShare
{
    internal class LoginResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
