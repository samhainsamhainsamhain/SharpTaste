using Microsoft.AspNetCore.Mvc;
using SharpTaste.Contracts;

namespace SharpTaste.Controllers
{
    [ApiController]
    public class BreakfastsController : Controller
    {
        [HttpPost("/breakfasts")]
        public IActionResult CreateBreakfastRequest(CreateBreakfastRequest request)
        {
            return Ok(request);
        }

        [HttpGet("/breakfasts/{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            return Ok(id);
        }

        [HttpPut("/breakfasts/{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            return Ok(request);
        }

        [HttpDelete("/breakfasts/{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            return Ok(id);
        }
    }
}
