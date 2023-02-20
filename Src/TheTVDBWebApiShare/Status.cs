using System.Text.Json.Serialization;

namespace TheTVDBWebApiShare
{
    public class Status
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("keepUpdated")]
        public bool KeepUpdated { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("recordType")]
        public string RecordType { get; set; }
    }
}
