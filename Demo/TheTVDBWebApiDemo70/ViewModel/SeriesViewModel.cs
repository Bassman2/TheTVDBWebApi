namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class SeriesViewModel : ObservableObject
    {
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");

        public SeriesViewModel(SeriesBaseRecord record)
        {
            this.SeriesListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb())
                {
                    await client.LoginAsync(apiKey, userKey);
                    this.SeriesBaseRecord = await client.GetSeriesAsync(record.Id);
                    this.SeriesExtendedRecord = await client.GetSeriesExtendedAsync(record.Id);
                }
            });
        }

        [ObservableProperty]
        private SeriesBaseRecord seriesListRecord;

        [ObservableProperty]
        private SeriesBaseRecord seriesBaseRecord;

        [ObservableProperty]
        private SeriesExtendedRecord seriesExtendedRecord;
    }
}
