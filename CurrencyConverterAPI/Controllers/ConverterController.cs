using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly IConverterService _converterService;

        public ConverterController(IConverterService converterService)
        {
            _converterService = converterService;
        }

        [HttpGet("getcurrencytypes")]
        public IActionResult GetCurrencyTypes()
        {
            var result = _converterService.GetCurrencies();
            return Ok(result);
        }

        [HttpGet("convertcurrencies")]
        public IActionResult ConvertCurrencies(string currentCurrency, string targetCurrency, double amount)
        {
            GetCurrencyTypes();
            var result = _converterService.ConvertCurrencies(currentCurrency, targetCurrency, amount);
            return Ok(result);
        }
    }
}