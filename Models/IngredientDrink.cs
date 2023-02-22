namespace DrinksWebApp.Models
{
    public partial class IngredientDrink
    {
        public int Id { get; set; }

        public int IngredientId { get; set; }

        public int DrinkId { get; set; }

        public string Quantity { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public virtual Drink Drink { get; set; }
    }
}
