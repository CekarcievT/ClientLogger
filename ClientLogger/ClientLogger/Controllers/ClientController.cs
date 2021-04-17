using ClientLogger.Business.Interfaces;
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

    }
}
