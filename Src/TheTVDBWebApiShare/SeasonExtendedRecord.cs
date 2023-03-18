namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Extended season record.
    /// </summary>
    public class SeasonExtendedRecord : SeasonBaseRecord
    {
        [JsonPropertyName("episodes")]
        public List<EpisodeBaseRecord> Episodes { get; set; }

        [JsonPropertyName("trailers")]
        public List<Trailer> Trailers { get; set; }

        [JsonPropertyName("artwork")]
        public List<ArtworkBaseRecord> Artwork { get; set; }
        
        
        [JsonPropertyName("tagOptions")]
        public List<TagOption> TagOptions { get; set; }

        // not exists in json response
        //[JsonPropertyName("translations")]
        //public List<Translation> Translations { get; set; }

        
    }
}
