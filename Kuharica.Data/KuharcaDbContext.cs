using kuharica.Data.Entities;
using Kuharica.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kuharica.Data
{
	public class KuharcaDbContext : DbContext
	{
		public KuharcaDbContext(DbContextOptions<KuharcaDbContext> options) : base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<ConvertMeasurementUnit> ConvertMeasurementUnits { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<Meal> Meals { get; set; }
		public DbSet<MealIngredient> MealIngredients { get; set; }
		public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
		public DbSet<NutritionalValue> NutritionalValues { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}

	
}

