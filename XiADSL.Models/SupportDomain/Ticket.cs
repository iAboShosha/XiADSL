using System;
using System.Collections.Generic;
using XiADSL.Arc;
using XiADSL.Models.Shape;

namespace XiADSL.Models.SupportDomain
{
    public class Ticket : BaseModel
    {
        public Ticket()
        {
            Created = DateTime.Now;
            
            StatusId = 1;
        }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public Problem Problem { get; set; }

        public DateTime? ReSolved { get; set; }

        public CustomerShape Customer { get; set; }
        public EmployeeShape Creator { get; set; }
        public EmployeeShape Assingn { get; set; }
        public string CloseNode { get; set; }

        public Status Status { get; set; }
        public bool IsClosed { get; set; }
        public ICollection<Action> Actions { get; set; }


        public int ProblemId { get; set; }
        public int CustomerId { get; set; }
        public int? CreatorId { get; set; }
        public int? AssingnId { get; set; }
        public int StatusId { get; set; }

    }
}