﻿namespace TheTVDBWebApiShare
{
    /// <summary>
    /// An alias model, which can be associated with a series, season, movie, person, or list.
    /// </summary>
    public class Alias
    {
        /// <summary>
        /// A 3-4 character string indicating the language of the alias, as defined in Language.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// A string containing the alias itself.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
