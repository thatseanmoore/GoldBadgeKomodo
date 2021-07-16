using CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CafeTest
{
    [TestClass]
    public class MenuContentRepositoryTests
    {
        MenuContentRepo _repo;

        [TestInitialize]
        public void AddMenuContentToList()
        {
            _repo = new MenuContentRepo();

            MenuContent one = new MenuContent(MealNumber.One, "Number One", "Chicken Tendies & Fries", "Thick Solid Full Chicken Tendie, Ketchup, French Fries",
                "$10");
            _repo.AddMenuContentToList(one);
        }

        [TestMethod]
        public void AddMenuContentToList_Test()
        {
            _repo.AddMenuContentToList(new MenuContent());

            Assert.AreEqual(2, _repo.GetMenuContentList().Count);

        }
        [TestMethod]
        public void RemoveMenuContentFromList_Test()
        {
            _repo.RemoveMenuContentFromList(new MealNumber());

            Assert.AreEqual(1, _repo.GetMenuContentList().Count);
        }

        [TestMethod]
        public void GetContentByMealNumber_Test()
        {
            _repo.GetContentByMealNumber(new MealNumber());

            Assert.AreEqual(1, _repo.GetMenuContentList().Count);
        }
    }
}