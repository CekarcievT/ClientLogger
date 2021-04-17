using Microsoft.AspNetCore.Mvc;

namespace ClientLogger.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult JsonValidation(string[] rules)
        {
            return new JsonResult(new { errors = rules });
        }

        protected ActionResult JsonData(object obj)
        {
            return new JsonResult(new { errors = new { }, data = obj });
        }
    }
}
