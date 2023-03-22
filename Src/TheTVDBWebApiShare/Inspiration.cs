using System;
using System.Collections.Generic;
using System.Text;

namespace TheTVDBWebApi
{
    /// <summary>
    /// Movie inspiration record.
    /// </summary>
    public class Inspiration
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("type_name")]
        public string TypeName { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
