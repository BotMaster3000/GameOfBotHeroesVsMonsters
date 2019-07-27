using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Interfaces
{
    public interface IBuildingCreator
    {
        IBuilding CreateBuilding(BuildingTypes buildingType);
    }
}
