namespace TheTVDBWebApi
{
    /// <summary>
    /// Entity Type record.
    /// </summary>
    public class EntityType
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
   
        [JsonPropertyName("hasSpecials")]
        public bool HasSpecials { get; set; }
    }
}
