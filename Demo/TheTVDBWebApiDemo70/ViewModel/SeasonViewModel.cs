namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class SeasonViewModel : ObservableObject
    {
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");

        public SeasonViewModel(SeasonBaseRecord record)
        {
            this.SeasonListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb())
                {
                    await client.LoginAsync(apiKey, userKey);
                    this.SeasonBaseRecord = await client.GetSeasonAsync(record.Id);
                    this.SeasonExtendedRecord = await client.GetSeasonExtendedAsync(record.Id);
                }
            });
        }

        [ObservableProperty]
        private SeasonBaseRecord seasonListRecord;

        [ObservableProperty]
        private SeasonBaseRecord seasonBaseRecord;

        [ObservableProperty]
        private SeasonExtendedRecord seasonExtendedRecord;
    }
}
