using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Logic;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLibTests
{
    [TestClass]
    public class BuildingCreatorTests
    {
        [TestMethod]
        public void CreateBuildingTest()
        {
            foreach(BuildingTypes buildingType in Enum.GetValues(typeof(BuildingTypes)))
            {
                BuildingCreator creator = new BuildingCreator();
                IBuilding building = creator.CreateBuilding(buildingType);

                Assert.AreEqual(buildingType, building.BuildingType);
            }
        }

        [TestMethod]
        public void GenerateBuildingTest_Tavern()
        {
            IsValidBuilding(BuildingTypes.Tavern);
        }

        [TestMethod]
        public void GenerateBuildingTest_Inn()
        {
            IsValidBuilding(BuildingTypes.Inn);
        }

        [TestMethod]
        public void GenerateBuildingTest_WeaponShop()
        {
            IsValidBuilding(BuildingTypes.WeaponShop);
        }

        [TestMethod]
        public void GenerateBuildingTest_ArmorShop()
        {
            IsValidBuilding(BuildingTypes.ArmorShop);
        }

        [TestMethod]
        public void GenerateBuildingTest_ItemShop()
        {
            IsValidBuilding(BuildingTypes.ItemShop);
        }

        [TestMethod]
        public void GenerateBuildingTest_BitOfEverything()
        {
            IsValidBuilding(BuildingTypes.BitOfEverythingStore);
        }

        private void IsValidBuilding(BuildingTypes buildingType)
        {
            BuildingCreator creator = new BuildingCreator();
            IBuilding building = creator.RandomGenerateBuilding(buildingType);

            Assert.AreEqual(buildingType, building.BuildingType);
            Assert.IsTrue(building.Shop.ShopInventory.ShopItems.Length > 0);
        }
    }
}
