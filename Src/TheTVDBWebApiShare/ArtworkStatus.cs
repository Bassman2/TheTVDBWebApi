namespace TheTVDBWebApiShare
{
    public class ArtworkStatus
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
