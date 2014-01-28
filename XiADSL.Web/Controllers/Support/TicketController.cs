using System.Net.Http;
using XiADSL.Arc;
using XiADSL.Models.SupportDomain;
using XiADSL.Web.Controllers._base;

namespace XiADSL.Web.Controllers.Support
{
    public class TicketController : RackController<Ticket>
    {
        public TicketController(IRepository<Ticket> repository)
            : base(repository)
        {
        }

        public override HttpResponseMessage Post(Ticket item)
        {
            item.CreatorId = 1;
            return base.Post(item);
        }
    }
}