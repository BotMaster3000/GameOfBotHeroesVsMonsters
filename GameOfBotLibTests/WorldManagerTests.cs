using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Logic;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Models.Map;
using GameOfBotLib.Enums;

namespace GameOfBotLibTests
{
    [TestClass]
    public class WorldManagerTests
    {
        private const int MapWidth = 10;
        private const int MapHeight = 10;
        private readonly IDictionary<TileValues, int> tileValueAndAppearanceChance = new Dictionary<TileValues, int>()
        {
            { TileValues.City, 10 },
            { TileValues.Forest, 10 },
            { TileValues.Fortress, 10 },
            { TileValues.Grassland, 10 },
            { TileValues.Village, 10 },
        };

        private readonly IDictionary<CreatureTypes, int> creatureTypeAndAppearanceChance = new Dictionary<CreatureTypes, int>()
        {
            { CreatureTypes.Human, 10 },
            { CreatureTypes.Goblin, 10 },
            { CreatureTypes.Troll, 10 },
        };

        private ITime time;
        private IMap map;

        private void SetupTest()
        {
            time = new Time();
            MapCreator creator = new MapCreator();
            map = creator.GenerateFlatMap(MapWidth, MapHeight, tileValueAndAppearanceChance);
            creator.GenerateMapElements(map);
            creator.AddCreaturesToMap(map, creatureTypeAndAppearanceChance);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            SetupTest();
            WorldManager manager = new WorldManager(map, time);
            Assert.AreEqual(map, manager.Map);
            Assert.AreEqual(time, manager.Time);
        }

        [TestMethod]
        public void NextTurnTest()
        {
            SetupTest();
            WorldManager manager = new WorldManager(map, time);
            int currentDay = manager.Time.Day;
            int currentHour = manager.Time.Hour;
            int currentMinute = manager.Time.Minute;
            manager.NextTurn();
            Assert.AreEqual(currentDay, manager.Time.Day);
            Assert.AreEqual(currentHour, manager.Time.Hour);
            Assert.AreEqual(currentMinute + 1, manager.Time.Minute);
        }
    }
}
