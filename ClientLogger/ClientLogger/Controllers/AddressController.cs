using ClientLogger.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientLogger.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpPost("AggregateByField")]
        // [ApiExceptionFilter]
        public virtual IActionResult AggregateByField(string field)
        {
            var result = _addressService.AggregateByField(field);
            return JsonData(result);
        }

    }
}
