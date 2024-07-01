using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kuharica.Data.Entities
{
	public class MealIngredient
	{
		public int MealId { get; set; }
		public int IngredientId { get; set; } 
		public double Quantity { get; set; }
		public int MeasurementUnitId { get; set; }

		public virtual Meal Meal { get; set; }
		public virtual Ingredient Ingredient { get; set; }
		public virtual MeasurementUnit MeasurementUnit { get; set; }
	}

	public class MealIngredientConfigurationBuilder : IEntityTypeConfiguration<MealIngredient>
	{
        public MealIngredientConfigurationBuilder()
        {
        }

		public void Configure(EntityTypeBuilder<MealIngredient> builder)
		{
			builder.ToTable(nameof(MealIngredient));
			builder.HasKey(k => new { k.MealId, k.IngredientId});
			builder.HasOne(x => x.Meal)
				.WithMany()
				.HasForeignKey(x => x.MealId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(x => x.Ingredient)
				.WithMany()
				.HasForeignKey(x => x.IngredientId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.MeasurementUnit)
				.WithMany()
				.HasForeignKey(x => x.MeasurementUnitId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
