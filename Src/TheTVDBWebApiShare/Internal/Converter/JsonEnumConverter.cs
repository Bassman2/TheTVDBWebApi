//namespace TheTVDBWebApi.Internal.Converter
//{
//    internal class JsonEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, System.Enum
//    {
//        private struct Item
//        {
//            public TEnum Value;
//            public string? Name;
//        }

//        private readonly IEnumerable<Item> items;

//        public JsonEnumConverter()
//        {
//            this.items = Enum.GetValues<TEnum>().Select(i => new Item() { Value = i, Name = i.Value() });
//        }

//        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//        {
//            string? name = reader.GetString();
//            return this.items.FirstOrDefault(i => i.Name == name).Value;
//        }

//        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
//        {
//            writer.WriteStringValue(this.items.FirstOrDefault(i => i.Value.Equals(value)).Name);
//        }
//    }
//}
