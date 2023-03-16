using System.Windows.Media.Imaging;

namespace TheTVDBWebApiDemo.Converter
{
    [ValueConversion(typeof(string), typeof(ImageSource))]
    public class ImageLoadConverter : IValueConverter
    {
        private static readonly Uri imageBaseUri = new Uri("https://artworks.thetvdb.com");

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string url = (string)value;
            Uri uri = url.StartsWith("http") ? new Uri(url) : new Uri(imageBaseUri, url);
            BitmapImage bitmap = new BitmapImage(uri);
            return (ImageSource)bitmap;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
