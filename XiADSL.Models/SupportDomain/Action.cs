using System;
using XiADSL.Arc;
using XiADSL.Models.Shape;

namespace XiADSL.Models.SupportDomain
{
    public class Action : BaseModel
    {
        public EmployeeShape Creator { get; set; }
        public DateTime Created { get; set; }

        public Status Status { get; set; }
        public string Note { get; set; }

        public int CreatorId { get; set; }
        public int StatusId { get; set; }

        public int TicketId { get; set; }
    }
}