namespace TheTVDBWebApi
{
    [JsonSourceGenerationOptions]
    [JsonSerializable(typeof(Alias))]
    [JsonSerializable(typeof(ArtworkBaseRecord))]
    [JsonSerializable(typeof(ArtworkExtendedRecord))]
    [JsonSerializable(typeof(ArtworkStatus))]
    [JsonSerializable(typeof(ArtworkType))]
    [JsonSerializable(typeof(AwardBaseRecord))]
    internal partial class SourceGenerationContext : JsonSerializerContext
    {
    }
}
