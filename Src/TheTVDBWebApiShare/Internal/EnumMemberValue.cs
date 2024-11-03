namespace TheTVDBWebApi.Internal
{
    internal static class EnumMemberValue
    {
        public static string? Value<TEnum>(this TEnum enumVal)
        {
            return typeof(TEnum).GetMember(enumVal?.ToString()!).FirstOrDefault()?.GetCustomAttributes(typeof(EnumMemberAttribute), false).Cast<EnumMemberAttribute>().FirstOrDefault()?.Value;
        }
    }
}
