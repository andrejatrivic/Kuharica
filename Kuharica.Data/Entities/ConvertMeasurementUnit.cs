using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kuharica.Data.Entities
{
	public class ConvertMeasurementUnit
	{
		public int UnitFromId { get; set; }
		public int UnitToId { get; set; }	
		public double Factor { get; set; }

		public virtual MeasurementUnit MeasurementUnit { get; set; }
	}

	public class ConvertMeasurementUnitConfigurationBuilder : IEntityTypeConfiguration<ConvertMeasurementUnit>
	{
		public ConvertMeasurementUnitConfigurationBuilder()
		{

		}

		public void Configure(EntityTypeBuilder<ConvertMeasurementUnit> builder)
		{
			builder.ToTable(nameof(ConvertMeasurementUnit));
			builder.HasKey(k => new {k.UnitFromId, k.UnitToId});
			builder.HasOne(x => x.MeasurementUnit)
				.WithMany()
				.HasForeignKey(x => x.UnitFromId)
				.HasForeignKey(x => x.UnitToId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
