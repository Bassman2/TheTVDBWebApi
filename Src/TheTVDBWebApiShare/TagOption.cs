﻿namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Tag option record.
    /// </summary>
    public class TagOption
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }       

        [JsonPropertyName("tag")]
        public long Tag { get; set; }

        [JsonPropertyName("tagName")]
        public string TagName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("helpText")]
        public string HelpText { get; set; }
    }
}
