using System.Security.Policy;
using System.Windows.Media.Imaging;

namespace TheTVDBWebApiDemo.Controls
{
    /// <summary>
    /// Interaction logic for ImageControl.xaml
    /// </summary>
    public partial class ImageControl : UserControl
    {
        private static readonly Uri imageBaseUri = new Uri("https://artworks.thetvdb.com");

        public ImageControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ImageControl),
                new FrameworkPropertyMetadata(null));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(string), typeof(ImageControl),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnImageChanged)));

        public string Image
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        private static void OnImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageControl view = (ImageControl)d;
            string url = e.NewValue as string;
            if (String.IsNullOrEmpty(url))
            {
                view.ImageSource = null;
            }
            else
            {
                Uri uri = url.StartsWith("http") ? new Uri(url) : new Uri(imageBaseUri, url);
                BitmapImage bitmap = new BitmapImage(uri);
                view.ImageSource = (ImageSource)bitmap;
            }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageControl),
                new FrameworkPropertyMetadata(null));

        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }
    }
}
