using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.ActionParameters
{
    public class MoveCreatureActionParameter : IActionParameter
    {
        public ITile CurrentCreatureTile { get; set; }
        public ITile NewCreatureTile { get; set; }
        public ICreature Creature { get; set; }
    }
}
