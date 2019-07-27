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
            const BuildingTypes Type = BuildingTypes.ArmorShop;

            BuildingCreator creator = new BuildingCreator();
            IBuilding building = creator.CreateBuilding(Type);
            Assert.AreEqual(Type, building.BuildingType);
        }
    }
}
