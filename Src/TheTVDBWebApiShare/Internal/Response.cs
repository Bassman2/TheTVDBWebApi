﻿namespace TheTVDBWebApiShare
{
    internal class Response<T> where T : class
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("links")]
        public Links Links { get; set; }
    }
}