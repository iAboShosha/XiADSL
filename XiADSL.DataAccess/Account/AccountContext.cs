using System.Collections.Generic;
using System.Data.Entity;
using XiADSL.Arc;
using XiADSL.DataAccess._base;
using XiADSL.Models.AccountDomain;

namespace XiADSL.DataAccess
{
    public class AccountContext : BaseContext<AccountContext>
    {
        

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
    }
}