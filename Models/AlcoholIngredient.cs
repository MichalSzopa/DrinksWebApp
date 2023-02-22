namespace DrinksWebApp.Models
{
    public partial class AlcoholIngredient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal AlcoholVolume { get; set; }

        public virtual ICollection<AlcoholIngredientDrink> AlcoholIngredientDrinks { get; set; }
    }
}
