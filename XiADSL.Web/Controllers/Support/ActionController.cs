using XiADSL.Arc;
using XiADSL.Web.Controllers._base;

namespace XiADSL.Web.Controllers.Support
{
    public class ActionController : RackController<XiADSL.Models.SupportDomain.Action>
    {
        public ActionController(IRepository<XiADSL.Models.SupportDomain.Action> repository)
            : base(repository)
        {
        }
    }
}