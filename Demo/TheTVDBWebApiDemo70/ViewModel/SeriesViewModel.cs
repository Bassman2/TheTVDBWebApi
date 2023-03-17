namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class SeriesViewModel : ObservableObject
    {
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");

        public SeriesViewModel(SeriesBaseRecord seriesBaseRecord)
        {
            this.SeriesBaseRecord = seriesBaseRecord;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb())
                {
                    await client.LoginAsync(apiKey, userKey);
                    this.SeriesExtendedRecord = await client.GetSeriesExtendedAsync(seriesBaseRecord.Id);
                }
            });
        }

        [ObservableProperty]
        private SeriesBaseRecord seriesBaseRecord;

        [ObservableProperty]
        private SeriesExtendedRecord seriesExtendedRecord;
    }
}
