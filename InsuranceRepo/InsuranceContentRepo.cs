using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceRepo
{
    public class InsuranceContentRepo
    {
        private Dictionary<int, List<string>> _listOfBadges = new Dictionary<int, List<string>>();

        public void AddBadge(InsuranceContent badge)
        {
            if(badge != null)
            {
                _listOfBadges.Add(badge.BadgeID, badge.DoorNames);
            }
        }
        public Dictionary<int, List<string>> GetListOfBadges()
        {
            return _listOfBadges;
        }

        public void AddDoorAccess(int badgeID, string doorNames)
        {
            List<string> door = _listOfBadges[badgeID];
            door.Add(doorNames);
            _listOfBadges[badgeID] = door;
        }
        public List<string> GetDoorList(int badgeNum)
        {
            if (! _listOfBadges.ContainsKey(badgeNum))
            {
                Console.WriteLine("Cannot find selected badgeID.");
                return new List<string>();
            }
            return _listOfBadges[badgeNum];
        }
        public void RemoveDoorAccess (int badgeID, string doorNames)
        {
            if(! _listOfBadges.ContainsKey(badgeID))
            {
                Console.WriteLine("Cannot find selected badgeID.");
            }
            List<string> door = _listOfBadges[badgeID];
            door.Remove(doorNames);
            _listOfBadges[badgeID] = door;
        }

    }
}
