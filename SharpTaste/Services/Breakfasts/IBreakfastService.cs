using SharpTaste.Contracts;
using SharpTaste.Models;
using ErrorOr;

namespace SharpTaste.Services.Breakfasts
{
    public interface IBreakfastService
    {
        ErrorOr<Created> CreateBreakfast(Breakfast request);
        ErrorOr<Deleted> DeleteBreakfast(Guid id);
        ErrorOr<Breakfast> GetBreakfast(Guid id);
        ErrorOr<UpsertedBreakfast> UpsertBreakfast(Breakfast breakfast);
    }
}
