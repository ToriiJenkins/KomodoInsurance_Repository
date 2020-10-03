using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeSystem_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }

        public List<string> DoorList { get; set; } //= new List<string>();

        public string Name { get; set; }

        public Badge() { }

        public Badge(int badgeID, List<string> doorList, string name)
        {
            BadgeID = badgeID;
            DoorList = doorList;
            Name = name;
        }

    }
}
