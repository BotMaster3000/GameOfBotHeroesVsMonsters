using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Interfaces
{
    public interface IMapCreator
    {
        IMap GenerateFlatMap(int mapWidth, int mapHeight, IDictionary<TileValues, int> tilevalueAndAppearanceChance);
        void GenerateMapElements(IMap map);
    }
}
