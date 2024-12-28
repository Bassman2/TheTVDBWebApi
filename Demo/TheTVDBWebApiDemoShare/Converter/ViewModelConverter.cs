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
            if (value is SeasonBaseRecord season)
            {
                return new SeasonViewModel(season);
            }
            if (value is EpisodeBaseRecord episode)
            {
                return new EpisodeViewModel(episode);
            }
            if (value is ListBaseRecord list)
            {
                return new ListViewModel(list);
            }
            if (value is PeopleBaseRecord people)
            {
                return new PeopleViewModel(people);
            }
            if (value is Company company)
            {
                return new CompanyViewModel(company);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}