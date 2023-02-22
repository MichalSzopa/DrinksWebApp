#pragma warning disable CS8603
using DrinksWebApp.Data;
using DrinksWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinksWebApp.Services
{
    public class DrinkService
    {

        public DrinkService()
        {
        }

        public async Task<ICollection<Drink>> GetListAsync()
        {
            using var context = new DrinksAppContext();
            return await context.Drink.ToListAsync();
        }

        public async Task<Drink> GetDetails(int id)
        {
            using var context = new DrinksAppContext();
            return await context.Drink
            .Include(d => d.IngredientDrinks)
                .ThenInclude(d => d.Ingredient)
            .Include(d => d.AlcoholIngredientDrinks)
                .ThenInclude(d => d.AlcoholIngredient)
            .Include(d => d.Opinions)
            .Where(d => d.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task Add(Drink model, int[] ingredients, int[] alcoholIngredients)
        {
            using var context = new DrinksAppContext();
            await context.Drink.AddAsync(model);
            await context.SaveChangesAsync();

            var ingredientDrinks = new List<IngredientDrink>();
            foreach(var ingredient in ingredients)
            {
                ingredientDrinks.Add(new IngredientDrink()
                {
                    DrinkId = model.Id,
                    IngredientId = ingredient,
                    Quantity = "0",
                });
            }

            var alcoholIngredientDrinks = new List<AlcoholIngredientDrink>();
            foreach (var alcoholIngredient in alcoholIngredients)
            {
                alcoholIngredientDrinks.Add(new AlcoholIngredientDrink()
                {
                    DrinkId = model.Id,
                    AlcoholIngredientId = alcoholIngredient,
                });
            }

            await context.IngredientDrink.AddRangeAsync(ingredientDrinks);
            await context.AlcoholIngredientDrink.AddRangeAsync(alcoholIngredientDrinks);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<Drink>> GetByIngredients(List<int> ingredients, List<int> alcoholIngredients)
        {
            using var context = new DrinksAppContext();
            return await context.Drink
                .Include(d => d.IngredientDrinks)
                .Include(d => d.AlcoholIngredientDrinks)
                .Where(d => d.IngredientDrinks.Any(id => ingredients.Count() == 0 || ingredients.Contains(id.IngredientId)))
                .Where(d => d.AlcoholIngredientDrinks.Any(aid => alcoholIngredients.Count() == 0 || alcoholIngredients.Contains(aid.AlcoholIngredientId)))
                .ToListAsync();
        }

        public async Task<ICollection<Drink>> GetByUserId(string userId)
        {
            using var context = new DrinksAppContext();
            return await context.Drink
                .Include(d => d.IngredientDrinks)
                .Include(d => d.AlcoholIngredientDrinks)
                .Where(d => d.UserId == userId)
                .ToListAsync();
        }
    }
}
