namespace TheTVDBWebApi.Internal
{
    internal class Response
    {
        //[JsonPropertyName("data")]
        //public T Data { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("links")]
        public Links? Links { get; set; }
    }

    internal class Response<T> where T : class
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
        
        [JsonPropertyName("links")]
        public Links? Links { get; set; }
    }
}
