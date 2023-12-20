using DemoApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Configurations
{
    public class CarBrandConfiguration : IEntityTypeConfiguration<CarBrand>
    {
        public void Configure(EntityTypeBuilder<CarBrand> builder)
        {
            //especifying table name
            builder.ToTable("carbrand");
            //specifying key
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id");
            ///declare required and max length
            builder.Property(c => c.Name).IsRequired().HasMaxLength(250).HasColumnName("name");
            builder.Property(c => c.Description).HasMaxLength(250).HasColumnName("description");
        }
    }
}
