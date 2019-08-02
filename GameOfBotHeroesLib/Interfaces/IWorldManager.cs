using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface IWorldManager
    {
        IMap Map { get; }
        ITime Time { get; }
    }
}
