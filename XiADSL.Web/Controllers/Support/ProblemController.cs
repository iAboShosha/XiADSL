using XiADSL.Arc;
using XiADSL.Models.SupportDomain;
using XiADSL.Web.Controllers._base;

namespace XiADSL.Web.Controllers.Support
{
    public class ProblemController : RackController<Problem>
    {
        public ProblemController(IRepository<Problem> repository)
            : base(repository)
        {
        }
    }
}