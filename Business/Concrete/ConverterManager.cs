using Business.Abstract;
using System;
using System.Net.Http;

namespace Business.Concrete
{
    public class ConverterManager : IConverterService
    {
        public void ConvertCurrencies()
        {
            throw new System.NotImplementedException();
        }

        public HttpResponseMessage GetCurrencyTypes()
        {
            using (HttpClient client = new HttpClient() )
            {
                client.BaseAddress = new Uri("http://data.fixer.io");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/latest?access_key=94184938b2440eff5290ee5f3aaecfc3&format=1").Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                }

                return response;
            }

        }
    }
}
