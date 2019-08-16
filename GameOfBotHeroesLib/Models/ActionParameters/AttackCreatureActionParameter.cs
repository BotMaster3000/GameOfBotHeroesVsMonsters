using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.ActionParameters
{
    public class AttackCreatureActionParameter : IActionParameter
    {
        public ICreature AttackingCreature { get; set; }
        public ICreature DefendingCreature { get; set; }
    }
}
