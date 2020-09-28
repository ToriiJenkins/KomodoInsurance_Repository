using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_Repository
{
    class Menu_Repository
    {

        private List<MenuItem> _listOfMenuItems = new List<MenuItem>();


        //Create
        public void AddMenuItemToList(MenuItem menuItem)
        {
            _listOfMenuItems.Add(menuItem);
        }


        //Read 
        public List<MenuItem> GetMenuItemList()
        {
            return _listOfMenuItems;
        }

        //Update(add later)
        

        //Delete
        public bool RemoveMenuItemFromList(int mealNumber)
        {
            MenuItem oldItem = GetMenuItemByID(mealNumber);

            if(oldItem == null)
            {
                return false;
            }

            int initialMenuItemCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(oldItem);

           if(initialMenuItemCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//end RemoveMenuItemFromList


        //Helper Method Get MenuItem By ID
        public MenuItem GetMenuItemByID(int mealNumber)
        {
            foreach(MenuItem item in _listOfMenuItems)
            {
                if(item.Meal_Number == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }// end of GetMenuItemByID
    }
}
