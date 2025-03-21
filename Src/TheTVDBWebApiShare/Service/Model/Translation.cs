﻿namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Translation record.
/// </summary>
public class Translation
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("overview")]
    public string? Overview { get; set; }

    [JsonPropertyName("language")]
    public Languages Language { get; set; }


    [JsonPropertyName("aliases")]
    public List<string>? Aliases { get; set; }

    [JsonPropertyName("isAlias")]
    public bool IsAlias { get; set; }

    [JsonPropertyName("isPrimary")]
    public bool IsPrimary { get; set; }

    

   
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Only populated for movie translations. We disallow taglines without a title.</remarks>
    [JsonPropertyName("tagline")]
    public string? Tagline { get; set; }
}
