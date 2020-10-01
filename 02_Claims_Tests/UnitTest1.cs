using System;
using _02_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Claim_Repository _repo = new Claim_Repository();

        [TestInitialize]
        public void SeedRepository()
        {
            Claim claim1 = new Claim(15112, Claim.ClaimType.Car, "Client Rearended by non-client at Jefferson-Illinoi NW", 1234.99, new DateTime(2018,04,24), new DateTime(2018,04,27), true);
            Claim claim2 = new Claim(15113, Claim.ClaimType.Theft, "Theft from auto at residence", 760.00, new DateTime(2018, 05, 01), new DateTime(2018, 05, 07), true);

            _repo.AddClaimToList(claim1);
            _repo.AddClaimToList(claim2);
        }

        //Get
        [TestMethod]
        public void GetCountOfQueue()
        {
            int count = _repo.GetClaimList().Count;
            Assert.AreEqual(2, count);
        }
    }
}
