namespace TheTVDBWebApi
{
    public enum RecordType
    {
        /// <summary>
        /// Movie
        /// </summary>
        [EnumMember(Value = "movie")]
        [Description("Movie")]
        Movie,

        /// <summary>
        /// Series
        /// </summary>
        [EnumMember(Value = "series")]
        [Description("Series")]
        Series,
    }
}
