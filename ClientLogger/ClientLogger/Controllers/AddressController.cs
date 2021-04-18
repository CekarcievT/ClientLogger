using ClientLogger.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [HttpPost("AggregateByCountry")]
        // [ApiExceptionFilter]
        public virtual IActionResult AggregateByCountry(string property)
        {
            var result = _addressService.GetCountryAggregations(property);
            return JsonData(result);
        }

    }
}
