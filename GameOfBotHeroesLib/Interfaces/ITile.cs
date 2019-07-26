using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Interfaces
{
    public interface ITile
    {
        int XPos { get; }
        int YPos { get; }
        TileValues TileValue { get; }
        BuildingTypes[] BuildingTypes { get; }
        ITile[] NeighboringTiles { get; }
    }
}
