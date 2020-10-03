using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeSystem_Repository
{
    public class Badge_Repository
    {
        private Dictionary<int, Badge> _badgesList = new Dictionary<int, Badge>();

        //Create
        public void AddBadgeToDictionary(Badge newbadge)
        {
            _badgesList.Add(newbadge.BadgeID, newbadge);

        }

        //Read
        public Dictionary<int, Badge> GetBadgesList()
        {
            return _badgesList;
        }

        //Update
        public bool UpdateBadge(int badgeID, Badge newInfoBadge)
        {
            //Find the Content
            Badge badgeToUpdate = GetBadgeByID(badgeID);

            //Update the Content
            if (badgeToUpdate != null)
            {
                badgeToUpdate.BadgeID = newInfoBadge.BadgeID;
                badgeToUpdate.DoorList = newInfoBadge.DoorList;
                badgeToUpdate.Name = newInfoBadge.Name;

                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete
        public bool RemoveBadgeFromDictionary(int badgeID)
        {
            
            if (_badgesList.ContainsKey(badgeID))
            {
                _badgesList.Remove(badgeID);
                return true;
            }
            else
            {
                return false;
            }
        }//end RemoveMenuItemFromList

        //Get Badge by ID
        public Badge GetBadgeByID(int badgeID)
         {
            
             foreach (KeyValuePair<int, Badge> badge in _badgesList)
             {
                 if(badge.Key == badgeID)
                 {
                     return badge.Value;
                 }
               
             }

            return null;
         } 
    }
}
