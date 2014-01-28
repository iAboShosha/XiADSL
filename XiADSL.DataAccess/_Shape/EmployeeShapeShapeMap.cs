using System.Data.Entity.ModelConfiguration;
using XiADSL.Models.Shape;

namespace XiADSL.DataAccess._Shape
{
    public class EmployeeShapeMap : EntityTypeConfiguration<EmployeeShape>
    {
        public EmployeeShapeMap()
        {
            HasKey(t => t.Id);
            ToTable("Employees");

            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name").IsRequired();

        }
    }
}
