using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface IArmor : IItem
    {
        int Defense { get; }
    }
}
