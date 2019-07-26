using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface INamedCreature : ICreature
    {
        string Title { get; }
        string Name { get; }
    }
}
