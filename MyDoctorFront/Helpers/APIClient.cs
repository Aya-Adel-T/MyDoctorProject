﻿namespace FeliveryAdminPanel.Helpers
{
    public class APIClient
    {
        //To add methods to call API
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7292/api");
            return Client;
        }
    }
}
