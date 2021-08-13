using Entities.Concrete;

namespace Business.Abstract
{
    public interface IConverterService
    {
        CurrencyRate Rates { get; set; }
        CurrencyRate GetCurrencyTypes();

        int ConvertCurrencies(string currentCurrency, string targetCurrency, double amount);
    }
}
