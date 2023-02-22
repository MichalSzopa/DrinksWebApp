using DrinksWebApp.Data;
using DrinksWebApp.Models;

namespace DrinksWebApp.Services
{
    public class OpinionService
    {
        public async Task Add(Opinion opinion)
        {
            using var context = new DrinksAppContext();
            await context.AddAsync(opinion);
            await context.SaveChangesAsync();
        }
    }
}
