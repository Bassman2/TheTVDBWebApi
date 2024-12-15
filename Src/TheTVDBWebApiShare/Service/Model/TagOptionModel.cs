namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Tag option record.
/// </summary>
internal class TagOptionModel
{
    [JsonPropertyName("id")]
    public long Id { get; set; }       

    [JsonPropertyName("tag")]
    public long Tag { get; set; }

    [JsonPropertyName("tagName")]
    public string? TagName { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("helpText")]
    public string? HelpText { get; set; }
}
