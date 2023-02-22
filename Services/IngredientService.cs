using DrinksWebApp.Data;
using DrinksWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinksWebApp.Services
{
    public class IngredientService
    {

        public IngredientService()
        {
        }

        public async Task<Ingredient[]> GetAll()
        {
            using var context = new DrinksAppContext();
            return await context.Ingredient.ToArrayAsync();
        }

        public async Task Add(Ingredient model)
        {
            using var context = new DrinksAppContext();
            await context.Ingredient.AddAsync(model);
            await context.SaveChangesAsync();
        }
    }
}
