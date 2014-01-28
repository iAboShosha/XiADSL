using XiADSL.Arc;
using XiADSL.Models.SupportDomain;
using XiADSL.Web.Controllers._base;

namespace XiADSL.Web.Controllers.Support
{
    public class StatusController : RackController<Status>
    {
        public StatusController(IRepository<Status> repository)
            : base(repository)
        {
        }
    }
}