using System.Data.Entity;
using XiADSL.DataAccess.General;
using XiADSL.DataAccess._base;
using XiADSL.Models.GeneralDomain;

namespace XiADSL.DataAccess
{
    public class GeneralContext : BaseContext<GeneralContext>
    {
        

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new EmployeeMap());

        }
    }
}