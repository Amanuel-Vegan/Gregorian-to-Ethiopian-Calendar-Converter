using Converter.Application.Interface.IConverter;
using Microsoft.AspNetCore.Mvc;

namespace GregorianToEthiopianCalander.Controller
{
    [Route("api/Calendar-Converter")]
    [ApiController]
    public class CalendarConverterController : ControllerBase
    {
        private readonly IConverter _Converter;
        public CalendarConverterController(IConverter converter)
        {
            _Converter = converter;
        }

        [HttpGet]
        public string Get()
        {
            DateTime gregorianDate = new DateTime(2023, 4, 11);
            string ethiopianYear = _Converter.ConvertToEthiopianDate(gregorianDate);
            
            return ethiopianYear;
        }
    }
}
