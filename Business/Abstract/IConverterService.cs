using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IConverterService
    {
        Rate Rates { get; set; }
        List<Currency> Currencies { get; set; }

        List<Currency> GetCurrencies();

        double ConvertCurrencies(string currentCurrency, string targetCurrency, double amount);
    }
}