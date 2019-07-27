using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Models.Map;

namespace GameOfBotLib.Logic
{
    public class BuildingCreator : IBuildingCreator
    {
        public IBuilding CreateBuilding(BuildingTypes buildingType)
        {
            return new Building(buildingType);
        }
    }
}
