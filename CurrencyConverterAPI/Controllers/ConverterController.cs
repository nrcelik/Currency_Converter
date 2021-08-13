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

        [HttpGet("index")]
        public IActionResult Index()
        {
           var result = _converterService.GetCurrencyTypes();
            return Ok(result);
        }
    }
}