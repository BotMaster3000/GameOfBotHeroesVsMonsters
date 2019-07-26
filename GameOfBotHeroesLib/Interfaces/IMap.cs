using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface IMap
    {
        int Width { get; }
        int Height { get; }
        ITile[] Tiles { get; }
    }
}
