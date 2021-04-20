using ClientLogger.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ClientLogger.Infrastructure;

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
        [ApiExceptionFilter]
        [CustomAuthorizationFilter]
        public virtual IActionResult AggregateByField(string field)
        {
            var result = _addressService.AggregateByField(field);
            return JsonData(result);
        }

    }
}
