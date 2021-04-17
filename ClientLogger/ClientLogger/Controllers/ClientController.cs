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
    public class ClientController : BaseController
    {
        readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpPost("GetAllClients")]
        // [ApiExceptionFilter]
        public virtual IActionResult GetAllClients()
        {
            var result = _clientService.GetAllCLients();
            return JsonData(result);
        }

    }
}
