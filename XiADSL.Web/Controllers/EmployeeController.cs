using XiADSL.Arc;
using XiADSL.Models.GeneralDomain;
using XiADSL.Web.Controllers._base;

namespace XiADSL.Web.Controllers
{
    public class EmployeeController : RackController<Employee>
    {
        public EmployeeController(IRepository<Employee> repository)
            : base(repository)
        {
        }
    }
}