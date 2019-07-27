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

        public IBuilding RandomGenerateBuilding(BuildingTypes buildingType)
        {
            Building building = new Building(buildingType);

            ShopTypes shopType = buildingType switch
            {
                BuildingTypes.Tavern => ShopTypes.Tavern,
                BuildingTypes.Inn => ShopTypes.Inn,
                BuildingTypes.WeaponShop => ShopTypes.WeaponShop,
                BuildingTypes.ArmorShop => ShopTypes.ArmorShop,
                BuildingTypes.ItemShop => ShopTypes.ItemShop,
                BuildingTypes.BitOfEverythingStore => ShopTypes.BitOfEverythingShopType,
                _ => ShopTypes.UndefinedShopType,
            };

            ShopCreator shopCreator = new ShopCreator();
            building.SetShop(
                shopCreator.GenerateRandomShop(shopType));

            return building;
        }
    }
}
