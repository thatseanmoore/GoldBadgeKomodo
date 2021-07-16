using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceRepo
{
    public class InsuranceContent
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public string BadgeName { get; set; }
        public InsuranceContent() { }

        public InsuranceContent(int badgeID, List<string> doorNames, string badgeName)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
            BadgeName = badgeName;

        }

    }
}
