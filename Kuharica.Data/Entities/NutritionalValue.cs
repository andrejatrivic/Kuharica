using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kuharica.Data.Entities
{
	public class NutritionalValue
	{
		public int Id { get; set; }
		public int Kcal {  get; set; }
		public double Fat { get; set; }
		public double Protein { get; set; }
		public double Carbohydrates { get; set; }
		public double Sugar { get; set; }
		public int IngredientId { get; set; }

		public virtual Ingredient Ingredient { get; set; }
	}

	public class NutritionalValueConfigurationBuilder : IEntityTypeConfiguration<NutritionalValue>
	{
        public NutritionalValueConfigurationBuilder()
        {				
        }

		public void Configure(EntityTypeBuilder<NutritionalValue> builder)
		{
			builder.ToTable(nameof(NutritionalValue));
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Ingredient)
				.WithMany()
				.HasForeignKey(x => x.IngredientId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
