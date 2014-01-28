using System;
using XiADSL.Arc;

namespace XiADSL.Models.GeneralDomain
{
    public class Employee : BaseNameModel
    {
        public string PersonalCardNumber { get; set; }
        public DateTime? RecruitmentDate { get; set; }

        public string Address { get; set; }

        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }

        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
        public string Note { get; set; }

    }
}