using System.Data.Entity.ModelConfiguration;
using XiADSL.Models.Shape;

namespace XiADSL.DataAccess._Shape
{
    public class CustomerShapeMap : EntityTypeConfiguration<CustomerShape>
    {
        public CustomerShapeMap()
        {
            HasKey(t => t.Id);
            ToTable("Customer");

            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name").IsRequired();

        }
    }
}
