using XiADSL.Arc;
using XiADSL.Models.GeneralDomain;
using XiADSL.Web.Controllers._base;

namespace XiADSL.Web.Controllers
{
    public class CustomerController : RackController<Customer>
    {
        public CustomerController(IRepository<Customer> repository)
            : base(repository)
        {
        }
    }
}

