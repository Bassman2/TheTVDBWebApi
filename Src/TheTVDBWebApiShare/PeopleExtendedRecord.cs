namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Extended people record.
    /// </summary>
    public class PeopleExtendedRecord : PeopleBaseRecord
    {
        [JsonPropertyName("birth")]
        public DateOnly? Birth { get; set; }

        [JsonPropertyName("death")]
        public DateOnly? Death { get; set; }

        [JsonPropertyName("birthPlace")]
        public string BirthPlace { get; set; }

        [JsonPropertyName("remoteIds")]
        public List<RemoteID> RemoteIds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("gender")]
        public int? Gender { get; set; }

        [JsonPropertyName("characters")]
        public List<Character> Characters { get; set; }

        [JsonPropertyName("biographies")]
        public List<Biography> Biographies { get; set; }

        [JsonPropertyName("awards")]
        public List<AwardBaseRecord> Awards { get; set; }

        [JsonPropertyName("tagOptions")]
        public List<TagOption> TagOptions { get; set; }

        [JsonPropertyName("translations")]
        public TranslationExtended Translations { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        // not exists in json data
        //[JsonPropertyName("races")]
        //public List<Race> Races { get; set; }
    }
}

