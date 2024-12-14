namespace TheTVDBWebApi.Internal
{
    internal static class EnumMemberValue
    {
        public static string? Value<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]TEnum>(this TEnum enumVal) where TEnum : Enum
        {
            return typeof(TEnum).GetMember(enumVal?.ToString()!).FirstOrDefault()?.GetCustomAttributes(typeof(EnumMemberAttribute), false).Cast<EnumMemberAttribute>().FirstOrDefault()?.Value;
        }
    }
}
