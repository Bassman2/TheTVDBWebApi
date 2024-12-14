namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Entity record.
/// </summary>
public class Entity
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Can be null.</remarks>
    [JsonPropertyName("movieId")]
    public long? MovieId { get; set; }

    [JsonPropertyName("order")]
    public long Order { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Can be null.</remarks>
    [JsonPropertyName("seriesId")]
    public long? SeriesId { get; set; }
}
