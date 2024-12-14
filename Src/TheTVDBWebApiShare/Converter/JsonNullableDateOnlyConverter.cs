namespace TheTVDBWebApi.Internal.Converter
{
    internal class JsonNullableDateOnlyConverter : JsonConverter<DateOnly?>
    {
        public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (DateOnly.TryParseExact(reader.GetString()!, "yyyy-MM-dd", out DateOnly result))
            {
                return result;
            }
            return null;
        }

        public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
