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
    }
}
