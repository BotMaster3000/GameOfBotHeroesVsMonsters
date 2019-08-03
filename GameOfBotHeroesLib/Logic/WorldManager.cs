using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Logic
{
    public class WorldManager : IWorldManager
    {
        public IMap Map { get; }
        public ITime Time { get; }

        public void NextTurn()
        {
            Time.IncreaseMinute();
        }

        public WorldManager(IMap map, ITime time)
        {
            Map = map;
            Time = time;
        }
    }
}
