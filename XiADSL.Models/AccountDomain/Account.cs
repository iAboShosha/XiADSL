using System.Collections.Generic;
using XiADSL.Arc;

namespace XiADSL.Models.AccountDomain
{
    public class Account : BaseModel
    {
        public string DisplayName { get; set; }
        public string LoginName { get; set; }
        public int Type { get; set; }

        public ICollection<AccountRole> Roles { get; set; }
    }
}