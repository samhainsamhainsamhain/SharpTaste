using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharpTaste.Contracts;
using SharpTaste.Models;
using SharpTaste.ServiceErrors;
using SharpTaste.Services.Breakfasts;

namespace SharpTaste.Controllers
{
    public class BreakfastsController : ApiController
    {
        private readonly IBreakfastService _breakfastService;

        public BreakfastsController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfastRequest(CreateBreakfastRequest request)
        {
            ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.From(request);

            if (requestToBreakfastResult.IsError)
            {
                return Problem(requestToBreakfastResult.Errors);
            }

            var breakfast = requestToBreakfastResult.Value;

            // TODO save to db
            ErrorOr<Created> createBreakfastResult = _breakfastService.CreateBreakfast(breakfast);

            if (createBreakfastResult.IsError)
            {
                return Problem(createBreakfastResult.Errors);
            }
            return createBreakfastResult.Match(
                created => CreateAtGetBreakfast(breakfast),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);

            return getBreakfastResult.Match(
                breakfast => Ok(MapBreakfastResponse(breakfast)),
                errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            ErrorOr<Breakfast> requestBreakfastResult = Breakfast.From(id, request);

            if (requestBreakfastResult.IsError)
            {
                return Problem(requestBreakfastResult.Errors);
            }

            var breakfast = requestBreakfastResult.Value;

            ErrorOr<UpsertedBreakfast> upsertBreakfastResult = _breakfastService.UpsertBreakfast(breakfast);

            // TODO: return 201 if a new breakfast was created
            return upsertBreakfastResult.Match(
                upserted => upserted.IsNewlyCreated ? CreateAtGetBreakfast(breakfast) : NoContent(),
                errors => Problem(errors));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            ErrorOr<Deleted> deleteBreakfastResult = _breakfastService.DeleteBreakfast(id);

            return deleteBreakfastResult.Match(
                deleted => NoContent(),
                errors => Problem(errors));
        }

        private IActionResult CreateAtGetBreakfast(Breakfast breakfast)
        {
            return CreatedAtAction(
                 actionName: nameof(GetBreakfast),
                 routeValues: new { id = breakfast.Id },
                 value: MapBreakfastResponse(breakfast));
        }

        private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
        {
            return new BreakfastResponse(breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet);
        }
    }
}
