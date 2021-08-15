using Business.Abstract;
using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Business.Concrete
{
    public class ConverterManager : IConverterService
    {
        public Rate Rates { get; set; } = new Rate();
        public List<Currency> Currencies { get; set; } = new List<Currency>();

        public List<Currency> GetCurrencies()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://data.fixer.io");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/latest?access_key=5979df7ec69fcb9cf934f3272548093a&format=1").Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    Rates.Rates = JsonConvert.DeserializeObject<Rate>(content).Rates;

                    foreach (var type in Rates.Rates)
                    {
                        Currencies.Add(new Currency
                        {
                            CurrencyType = type.Key
                        });
                    }
                }
                return Currencies;
            }
        }

        public double ConvertCurrencies(string currentCurrency, string targetCurrency, double amount)
        {
            double targetPrice;
            double currentPrice;
            double newAmount = 0;

            foreach (var item in Currencies)
            {
                if (targetCurrency == item.CurrencyType)
                {
                    targetPrice = Convert.ToDouble(Rates.Rates.Where(p => p.Key == targetCurrency).Select(v => v.Value).FirstOrDefault());
                    currentPrice = Convert.ToDouble(Rates.Rates.Where(p => p.Key == currentCurrency).Select(v => v.Value).FirstOrDefault());

                    newAmount = (targetPrice / currentPrice) * amount;
                }
            }
            return newAmount;
        }
    }
}