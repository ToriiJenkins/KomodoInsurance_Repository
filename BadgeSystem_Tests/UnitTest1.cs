using System;
using BadgeSystem_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BadgeSystem_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Badge_Repository _repo = new Badge_Repository();

        [TestInitialize]
        public void SeedRepository()   
        {
            List<string> doorList1 = new List<string>() { "A1", "A3", "B7" };
            Badge badge1 = new Badge(1, doorList1, "John Dow");
            List<string> doorList2 = new List<string>(){ "C5", "D7" };
            Badge badge2 = new Badge(2, doorList2, "Jill Fern");
        }

       [TestMethod]
        public void GetDictionaryCount()
        {

            int count = _repo.GetBadgesList().Count;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TestGetBadgesList()
        {
            Dictionary<int, Badge> _badgesList = _repo.GetBadgesList();
            foreach (KeyValuePair<int, Badge> badgePair in _badgesList)
            {

                Console.WriteLine("{0,-15} ", badgePair.Key);
                for (int i = 0; i < badgePair.Value.DoorList.Count; i++)
                {
                    Console.WriteLine("          " + badgePair.Value.DoorList[i]);
                }

            }
        }




    }
}
