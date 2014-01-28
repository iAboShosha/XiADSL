using XiADSL.Arc;
using XiADSL.Models.Shape;

namespace XiADSL.Models.GeneralDomain
{
    public class Customer : BaseNameModel
    {

        public string PersonalCardNumber { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }

        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }

        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
        public string Note { get; set; }
        public Customer Parent { get; set; }
        public int? ParentId { get; set; }
    }
}
