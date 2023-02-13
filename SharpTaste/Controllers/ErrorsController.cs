using Microsoft.AspNetCore.Mvc;

namespace SharpTaste.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : Controller
    {
        [Route("error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
