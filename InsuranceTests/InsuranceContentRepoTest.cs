using InsuranceRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace InsuranceTests
{
    [TestClass]
    public class InsuranceContentRepositoryTests
    {
        InsuranceContentRepo _repo;

        [TestInitialize]
        public void AddBadge()
        {
            _repo = new InsuranceContentRepo();

            InsuranceContent cafeManager = new InsuranceContent(75429, "A1".Split(',').ToList<string>(), "Cafe Manager");
            InsuranceContent claimsAgent = new InsuranceContent(54264, "B1, C3, A4".Split(',').ToList<string>(), "Claims Agent");
            InsuranceContent insuranceManager = new InsuranceContent(12576, "A1, B1, C3, A4, C5".Split(',').ToList<string>(), "Insurance Manager");

            _repo.AddBadge(cafeManager);
            _repo.AddBadge(claimsAgent);
            _repo.AddBadge(insuranceManager);
        }

        [TestMethod]
        public void AddBadge_Test()
        {
            _repo.AddBadge(new InsuranceContent());

            Assert.AreEqual(4, _repo.GetListOfBadges().Count);
        }

        [TestMethod]
        public void AddDoorAccess_Test()
        {
            _repo.AddDoorAccess(75429, "B7");

            Assert.AreEqual(2, _repo.GetDoorList(75429).Count);
        }

        [TestMethod]
        public void RemoveDoorAccess_Test()
        {
            _repo.RemoveDoorAccess(12576, "A1");

            Assert.AreEqual(4, _repo.GetDoorList(12576).Count);
        }
    }
}