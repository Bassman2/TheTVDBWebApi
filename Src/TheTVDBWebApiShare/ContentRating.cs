﻿namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Content rating record.
    /// </summary>
    public class ContentRating
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("contentType")]
        public string ContentType { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
    }
}