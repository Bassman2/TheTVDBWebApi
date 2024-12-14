namespace TheTVDBWebApi;

public enum ContentType
{
    [EnumMember(Value = "episode")]
    [Description("Episode")]
    Episode,

    [EnumMember(Value = "movie")]
    [Description("Movie")]
    Movie,
}
