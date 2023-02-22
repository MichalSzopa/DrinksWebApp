using Microsoft.EntityFrameworkCore;
using DrinksWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DrinksWebApp.Data
{
	public class DrinksAppContext : IdentityDbContext
	{

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite("Data Source=databaza.db");
		}

		public DbSet<Ingredient> Ingredient { get; set; }

		public DbSet<AlcoholIngredient> AlcoholIngredient { get; set; }

		public DbSet<Drink> Drink { get; set; }

		public DbSet<AlcoholIngredientDrink> AlcoholIngredientDrink { get; set; }

		public DbSet<IngredientDrink> IngredientDrink { get; set; }

		public DbSet<Opinion> Opinion { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Drink>(entity =>
			{
				entity.ToTable("Drink");
			});

			modelBuilder.Entity<Ingredient>(entity =>
			{
				entity.ToTable("Ingredient");
			});

			modelBuilder.Entity<AlcoholIngredient>(entity =>
			{
				entity.ToTable("AlcoholIngredient");
			});

			modelBuilder.Entity<IngredientDrink>(entity =>
			{
				entity.ToTable("IngredientDrink");

				entity.HasIndex(e => e.DrinkId, "IXFK_IngredientDrink_Drink");

				entity.HasIndex(e => e.IngredientId, "IXFK_IngredientDrink_Ingredient");

				entity.HasIndex(e => new { e.DrinkId, e.IngredientId }, "UQ_IngredientDrink_IngredientDrinkId")
					.IsUnique();

				entity.HasOne(d => d.Drink)
					.WithMany(p => p.IngredientDrinks)
					.HasForeignKey(d => d.DrinkId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_IngredientDrink_Drink");

				entity.HasOne(d => d.Ingredient)
					.WithMany(p => p.IngredientDrinks)
					.HasForeignKey(d => d.IngredientId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_IngredientDrink_Ingredient");
			});

			modelBuilder.Entity<AlcoholIngredientDrink>(entity =>
			{
				entity.ToTable("AlcoholIngredientDrink");

				entity.HasIndex(e => e.DrinkId, "IXFK_AlcoholIngredientDrink_Drink");

				entity.HasIndex(e => e.AlcoholIngredientId, "IXFK_AlcoholIngredientDrink_Ingredient");

				entity.HasIndex(e => new { e.DrinkId, e.AlcoholIngredientId }, "UQ_AlcoholIngredientDrink_IngredientDrinkId")
					.IsUnique();

				entity.HasOne(d => d.Drink)
					.WithMany(p => p.AlcoholIngredientDrinks)
					.HasForeignKey(d => d.DrinkId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_AlcoholIngredientDrink_Drink");

				entity.HasOne(d => d.AlcoholIngredient)
					.WithMany(p => p.AlcoholIngredientDrinks)
					.HasForeignKey(d => d.AlcoholIngredientId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_AlcoholIngredientDrink_AlcoholIngredient");
			});

			modelBuilder.Entity<Opinion>(entity =>
			{
				entity.ToTable("Opinion");

				entity.HasIndex(e => e.DrinkId, "IXFK_Opinion_Drink");

				entity.HasOne(d => d.Drink)
					.WithMany(p => p.Opinions)
					.HasForeignKey(d => d.DrinkId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Opinion_Drink");
			});
		}
	}
}
