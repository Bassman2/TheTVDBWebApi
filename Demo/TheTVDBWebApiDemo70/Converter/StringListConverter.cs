namespace TheTVDBWebApiDemo.Converter
{
    [ValueConversion(typeof(List<string>), typeof(string))]
    public class StringListConverter : IValueConverter
    {
        private static readonly Uri imageBaseUri = new Uri("https://thetvdb.com");

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IEnumerable<string> list = (IEnumerable<string>)value;
            return list?.Aggregate("", (a, b) => $"{a}, {b}").Trim(',', ' ');
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
