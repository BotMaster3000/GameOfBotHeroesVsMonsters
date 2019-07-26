using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface IMapInterface
    {
        int Width { get; }
        int Height { get; }
        ITile[] Tiles { get; }
    }
}
