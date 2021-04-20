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
            var result = _clientService.CreateClient(clientFullInfo);
            return JsonData(result);
        }

        [HttpPost("UpdateClient")]
        // [ApiExceptionFilter]
        public virtual IActionResult UpdateClient(ClientFullInfo clientFullInfo)
        {
            _clientService.UpdateClient(clientFullInfo);
            return JsonData(new { });
        }

        [HttpPost("DeleteClient")]
        // [ApiExceptionFilter]
        public virtual IActionResult DeleteClient(ClientFullInfo clientFullInfo)
        {
            _clientService.DeleteClient(clientFullInfo);
            return JsonData(new { });
        }

    }
}
