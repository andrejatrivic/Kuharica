using Kuharica.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kuharica.Data.Entities
{
	public class Meal
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int CategoryId { get; set; }	

		public virtual Category Category { get; set; }
	}

	public class MealConfigurationBuilder : IEntityTypeConfiguration<Meal>
	{
        public MealConfigurationBuilder()
        {				
        }

		public void Configure(EntityTypeBuilder<Meal> builder)
		{
			builder.ToTable(nameof(Meal));
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Category)
				.WithMany()
				.HasForeignKey(x => x.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
