using System;
using System.Collections.Generic;
using System.Linq;
using Komodo_Insurance_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo_Insurance_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Menu_Repository _repo = new Menu_Repository();

        [TestInitialize]
        public void SeedRepository()
        {
            MenuItem item = new MenuItem(1, "Burger Meal", "Burger Fries and a Drink", new List<string> { "burger", "fries", "drink" }, 3.99);
            MenuItem item2 = new MenuItem(2, "Potato Meal", "Baked Potato and a Drink", new List<string> { "Packed Spud", "drink" }, 2.99);
            _repo.AddMenuItemToList(item);
            _repo.AddMenuItemToList(item2);
        }

        [TestMethod]
        public void GetCountAddedMenuItems()
        {

            int count = _repo.GetMenuItemList().Count;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void testGetMenuItemList()
        {
            List<MenuItem> listOfMItems = new List<MenuItem>();
            listOfMItems = _repo.GetMenuItemList();

            foreach(MenuItem item in listOfMItems)
            {
                Console.WriteLine(item.Meal_Name);
            }

            Assert.AreEqual(listOfMItems.Count(), 2);
        }

        [TestMethod]
        public void RemoveMenuItemFromListIsTrue()
        {
            int count = _repo.GetMenuItemList().Count;
            Console.WriteLine($"test list has {count} items--Before removal");

            bool test = _repo.RemoveMenuItemFromList(1);
            Assert.AreEqual(true, test);

            count = _repo.GetMenuItemList().Count;
            Console.WriteLine($"test list has {count} items--After removal");
        }

        [TestMethod]
        public void TestGetMenuItemById()
        {
            MenuItem testItem = new MenuItem();
            testItem = _repo.GetMenuItemByID(2);

            Console.WriteLine(testItem.Description);
            Assert.AreEqual(testItem.Meal_Name, "Potato Meal");
            
        }
    }
}
