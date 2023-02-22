using DrinksWebApp.Data;
using DrinksWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinksWebApp.Services
{
    public class AlcoholIngredientService
    {

        public AlcoholIngredientService()
        {
        }

        public async Task<AlcoholIngredient[]> GetAll()
        {
            using var context = new DrinksAppContext();
            return await context.AlcoholIngredient.ToArrayAsync();
        }

        public async Task Add(AlcoholIngredient model)
        {
            using var context = new DrinksAppContext();
            await context.AlcoholIngredient.AddAsync(model);
            await context.SaveChangesAsync();
        }
    }
}
