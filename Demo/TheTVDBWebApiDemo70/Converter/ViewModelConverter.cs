namespace TheTVDBWebApiDemo.Converter
{
    public class ViewModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is MovieBaseRecord movie)
            {
                return new MovieViewModel(movie);
            }
            if (value is SeriesBaseRecord series)
            {
                return new SeriesViewModel(series);
            }
            if (value is PeopleBaseRecord people)
            {
                return new PeopleViewModel(people);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}