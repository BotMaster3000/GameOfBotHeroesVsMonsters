using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.Creatures
{
    public class Monster : IMonster
    {
        public int ID { get; }

        public CreatureTypes CreatureType { get; }

        public int Health { get; set; }
    }
}
