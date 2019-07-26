using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Map
{
    public class Tile : ITile
    {
        public int XPos { get; }

        public int YPos { get; }

        public TileValues TileValue { get; }

        public BuildingTypes[] BuildingTypes { get; }

        public ITile[] NeighboringTiles { get; }
    }
}
