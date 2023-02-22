namespace DrinksWebApp.Models
{
    public partial class Opinion
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Rate { get; set; }

        public int DrinkId { get; set; }

        public virtual Drink Drink { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
