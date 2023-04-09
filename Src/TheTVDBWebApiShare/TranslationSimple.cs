namespace TheTVDBWebApi
{
    /// <summary>
    /// Translation simple record.
    /// </summary>
    public class TranslationSimple
    {
        [JsonPropertyName("deu")]
        public string Deu { get; set; }

        [JsonPropertyName("eng")]
        public string Eng { get; set; }

        [JsonPropertyName("fra")]
        public string Fra { get; set; }

        [JsonPropertyName("ita")]
        public string Ita { get; set; }

        [JsonPropertyName("kor")]
        public string Kor { get; set; }

        [JsonPropertyName("pol")]
        public string Pol { get; set; }

        [JsonPropertyName("por")]
        public string Por { get; set; }

        [JsonPropertyName("pt")]
        public string Pt { get; set; }

        [JsonPropertyName("spa")]
        public string Spa { get; set; }

        [JsonPropertyName("tur")]
        public string Tur { get; set; }
    }
}
