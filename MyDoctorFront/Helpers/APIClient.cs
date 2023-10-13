namespace FeliveryAdminPanel.Helpers
{
    public class APIClient
    {
        //To add methods to call API
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            //Client.BaseAddress = new Uri("https://mydoctorapi121852.azurewebsites.net/api");
            //Client.BaseAddress = new Uri("https://localhost:7292/api");
           // Client.BaseAddress = new Uri("https://ayaadelt-001-site1.gtempurl.com/api");
            Client.BaseAddress = new Uri("http://newapisforwebsite.tbibti.com/api");
            return Client;

        }
    }
    

}
