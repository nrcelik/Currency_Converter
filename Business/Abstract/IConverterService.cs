using System.Net.Http;

namespace Business.Abstract
{
    public interface IConverterService
    {
        HttpResponseMessage GetCurrencyTypes();

        void ConvertCurrencies();
    }
}
