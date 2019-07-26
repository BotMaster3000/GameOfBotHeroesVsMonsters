using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Map
{
    public class Map : IMap
    {
        public int Width { get; }

        public int Height { get; }

        public ITile[] Tiles { get; }
    }
}
