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
        IBuilding[] Buildings { get; }
        ITile[] NeighboringTiles { get; }

        IList<ICreature> CreatureList { get; }

        void SetBuildings(IBuilding[] buildings);
    }
}
