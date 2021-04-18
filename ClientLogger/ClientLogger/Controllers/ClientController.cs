using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("CreateClient")]
        // [ApiExceptionFilter]
        public virtual IActionResult CreateClient(ClientFullInfo clientFullInfo)
        {
            _clientService.CreateClient(clientFullInfo);
            return JsonData(new { });
        }

    }
}
