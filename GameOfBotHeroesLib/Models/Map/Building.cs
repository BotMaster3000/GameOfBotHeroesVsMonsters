using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Map
{
    public class Building : IBuilding
    {
        public BuildingTypes BuildingType { get; }

        public BuildingSizes BuildingSize { get; }

        public IShop Shop { get; private set; }

        public Building(BuildingTypes buildingType)
        {
            BuildingType = buildingType;
        }

        public void SetShop(IShop shop)
        {
            Shop = shop;
        }
    }
}
