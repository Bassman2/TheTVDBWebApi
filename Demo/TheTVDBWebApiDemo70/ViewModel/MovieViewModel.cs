using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class MovieViewModel : ObservableObject
    {
        private static readonly Uri imageBaseUri = new Uri("https://thetvdb.com");

        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");

        //private MovieBaseRecord movieBaseRecord;
        //private MovieExtendedRecord movieExtendedRecord;

        public MovieViewModel(MovieBaseRecord movieBaseRecord)
        {
            this.MovieBaseRecord = movieBaseRecord;
            //this.Img = new BitmapImage(new Uri(new Uri("https://api4.thetvdb.com"), movieBaseRecord.Image));

            //Uri ímgUrl =  new Uri(new Uri("https://thetvdb.com"), movieBaseRecord.Image);

            //BitmapImage bitmap = new BitmapImage(uímgurl);
            //this.BaseImage = LoadImage(movieBaseRecord.Image);





            Task.Run(async () =>
            {
                using (var client = new TVDBWeb())
                {
                    await client.LoginAsync(apiKey, userKey);
                    this.MovieExtendedRecord = await client.GetMovieExtendedAsync(movieBaseRecord.Id);
                }

                //this.ExtendedImage = LoadImage(movieExtendedRecord.Image);

            });
        }

        private ImageSource LoadImage(string url)
        {

            Uri uri = url.StartsWith("http") ? new Uri(url) : new Uri(imageBaseUri, url);

            BitmapImage bitmap = new BitmapImage(uri);
            return bitmap;
        }

        [ObservableProperty]
        private MovieBaseRecord movieBaseRecord;

        [ObservableProperty]
        private MovieExtendedRecord movieExtendedRecord;


        //public long BaseId => this.movieBaseRecord.Id;

        //public string BaseName => this.movieBaseRecord.Name;

        //public string BaseSlug => this.movieBaseRecord.Slug;

        //public string BaseImageUrl => this.movieBaseRecord.Image;

        //public ImageSource BaseImage { get; }



        //[ObservableProperty]
        //public long? ExtendedId => this.movieExtendedRecord?.Id;

        //public string ExtendedName => this.movieExtendedRecord?.Name;

        //public string ExtendedSlug => this.movieExtendedRecord?.Slug;
        
        //public string ExtendedImageUrl => this.movieExtendedRecord?.Image;

        //public ImageSource ExtendedImage { get; set; }

    }
}
