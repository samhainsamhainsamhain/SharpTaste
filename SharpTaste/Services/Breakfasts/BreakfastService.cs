using SharpTaste.Models;

namespace SharpTaste.Services.Breakfasts
{
    public class BreakfastService : IBreakfastService
    {
        // TODO move data storage from memory to db
        private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();

        public void CreateBreakfast(Breakfast breakfast)
        {
        _breakfasts.Add(breakfast.Id, breakfast);
        }

        public Breakfast GetBreakfast(Guid id)
        {
            return _breakfasts[id];
        }
    }
}
