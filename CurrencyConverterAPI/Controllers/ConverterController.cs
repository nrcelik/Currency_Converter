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
        public IActionResult ConvertCurrencies()
        {
            GetCurrencyTypes();
            var result = _converterService.ConvertCurrencies("TRY", "GBP", 10);
            return Ok(result);
        }

    }
}