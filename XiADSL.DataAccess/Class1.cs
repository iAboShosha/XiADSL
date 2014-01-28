using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using XiADSL.Models;
using XiADSL.Models.AccountDomain;
using XiADSL.Models.GeneralDomain;

namespace XiADSL.DataAccess
{

    public class BaseContext<T> : DbContext, IDbContext where T : DbContext
    {
        public BaseContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<T>(new DropCreateDatabaseIfModelChanges<T>());
        }

        public BaseContext(string cs)
            : base(cs)
        {
            Database.SetInitializer<T>(new DropCreateDatabaseIfModelChanges<T>());
        }
    }

    public interface IDbContext
    {
    }

    public class AccountContext : BaseContext<AccountContext>
    {

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
    }


    public class GeneralContext : BaseContext<AccountContext>
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
