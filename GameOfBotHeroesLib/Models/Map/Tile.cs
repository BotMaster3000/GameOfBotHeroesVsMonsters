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
        public IBuilding[] Buildings { get; private set; }

        public ITile[] NeighboringTiles { get; }

        public IList<ICreature> CreatureList { get; } = new List<ICreature>();

        public Tile(int xPox, int yPos, TileValues tileValue)
        {
            XPos = xPox;
            YPos = yPos;
            TileValue = tileValue;
        }

        public void SetBuildings(IBuilding[] buildings)
        {
            Buildings = buildings;
        }
    }
}
