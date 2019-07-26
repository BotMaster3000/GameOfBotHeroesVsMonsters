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

        public Map(int width, int height, ITile[] tiles)
        {
            Width = width;
            Height = height;
            Tiles = tiles;
        }
    }
}
