namespace DrinksWebApp.Models
{
    public partial class AlcoholIngredientDrink
    {
        public int Id { get; set; }

        public int AlcoholIngredientId { get; set; }

        public int DrinkId { get; set; }

        public virtual AlcoholIngredient AlcoholIngredient { get; set; }

        public virtual Drink Drink { get; set; }
    }
}
