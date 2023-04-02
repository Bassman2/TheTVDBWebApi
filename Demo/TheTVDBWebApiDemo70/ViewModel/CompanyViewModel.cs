namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class CompanyViewModel : ObservableObject
    {
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");

        public CompanyViewModel(Company record)
        {
            this.CompanyListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb())
                {
                    await client.LoginAsync(apiKey, userKey);
                    this.CompanyBaseRecord = await client.GetCompanyAsync(record.Id);
                }
            });
        }

        [ObservableProperty]
        private Company companyListRecord;

        [ObservableProperty]
        private Company companyBaseRecord;

        
    }
}
