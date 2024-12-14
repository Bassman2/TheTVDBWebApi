namespace TheTVDBWebApi.Internal
{
    internal class LoginRequest
    {
        [JsonPropertyName("apikey")]
        public string? ApiKey { get; set; }

        [JsonPropertyName("Pin")]
        public string? Pin { get; set; }
    }
}
