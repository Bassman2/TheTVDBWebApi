namespace TheTVDBWebApi.Service.Model;


public class SeriesEpisodes
{
    [JsonPropertyName("series")]
    public SeriesBaseRecord? Series { get; set; }

    [JsonPropertyName("episodes")]
    public List<EpisodeBaseRecord>? Episodes { get; set; }
}
