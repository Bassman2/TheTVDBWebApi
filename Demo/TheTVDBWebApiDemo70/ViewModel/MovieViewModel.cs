using System.Windows.Media.Imaging;

namespace TheTVDBWebApiDemo.ViewModel
{
    public class MovieViewModel : ObservableObject
    {
        private MovieBaseRecord movieBaseRecord;

        public MovieViewModel(MovieBaseRecord movieBaseRecord)
        {
            this.movieBaseRecord = movieBaseRecord;
            this.Bitmap = new BitmapImage(new Uri(new Uri("https://api4.thetvdb.com"), movieBaseRecord.Image));
        }

        public long Id => this.movieBaseRecord.Id;

        public string Name => this.movieBaseRecord.Name;

        public string Slug => this.movieBaseRecord.Slug;
        public string Image => this.movieBaseRecord.Image;

        public BitmapImage Bitmap { get; }
    }
}
