using System.Collections;

namespace TheTVDBWebApiDemo.Converter
{
    [ValueConversion(typeof(List<string>), typeof(string))]
    public class StringListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                Type type = value.GetType();
                 if (type == typeof(List<string>))
                {
                    IEnumerable<string> list = (IEnumerable<string>)value;
                    return list?.Aggregate("", (a, b) => $"{a}, {b}").Trim(',', ' ');
                }
                if (type.GetGenericArguments()[0].BaseType == typeof(Enum))
                {
                    var list = ((IList)value).Cast<Enum>().ToList();
                    return list?.Aggregate("", (a, b) => $"{a}, {b}").Trim(',', ' ');
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
