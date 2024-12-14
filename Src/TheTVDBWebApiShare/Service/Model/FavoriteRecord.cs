namespace TheTVDBWebApi.Service.Model;


public class FavoriteRecord
{
    [JsonPropertyName("series")]
    public int Series { get; set; }

    [JsonPropertyName("movies")]
    public int Movies { get; set; }

    [JsonPropertyName("episodes")]
    public int Episodes { get; set; }

    [JsonPropertyName("artwork")]
    public int Artwork { get; set; }

    [JsonPropertyName("people")]
    public int People { get; set; }

    [JsonPropertyName("list")]
    public int List { get; set; }
}
