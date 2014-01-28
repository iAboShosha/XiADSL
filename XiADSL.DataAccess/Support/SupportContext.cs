using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using XiADSL.Arc;
using XiADSL.DataAccess.Support;
using XiADSL.DataAccess._base;
using XiADSL.DataAccess._Shape;
using XiADSL.Models.Shape;
using XiADSL.Models.SupportDomain;

namespace XiADSL.DataAccess
{
    class SupportContext : BaseContext<SupportContext>
    {
        

        public DbSet<EmployeeShape> Employees { get; set; }
        public DbSet<CustomerShape> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Models.SupportDomain.Action> Actions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TicketMap());
            modelBuilder.Configurations.Add(new StatusMap());
            modelBuilder.Configurations.Add(new ProblemMap());
            modelBuilder.Configurations.Add(new ActionMap());
            modelBuilder.Configurations.Add(new EmployeeShapeMap());
            modelBuilder.Configurations.Add(new CustomerShapeMap());


        }
    }
}


