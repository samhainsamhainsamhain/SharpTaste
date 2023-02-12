using SharpTaste.Contracts;
using SharpTaste.Models;

namespace SharpTaste.Services.Breakfasts
{
    public interface IBreakfastService
    {
        void CreateBreakfast(Breakfast request);
        Breakfast GetBreakfast(Guid id);
    }
}
