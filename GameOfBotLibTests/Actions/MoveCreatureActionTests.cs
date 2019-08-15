using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Logic.Actions;
using GameOfBotLib.Models.ActionParameters;
using GameOfBotLib.Models.ActionResults;
using GameOfBotLib.Logic;
using GameOfBotLib.Enums;

namespace GameOfBotLibTests.Actions
{
    [TestClass]
    public class MoveCreatureActionTests
    {
        [TestMethod]
        public void MoveCreatureTest()
        {
            MapCreator creator = new MapCreator();
            IMap map = creator.GenerateFlatMap(2, 2, new Dictionary<TileValues, int> { { TileValues.Forest, 1 } });
            CreatureGenerator generator = new CreatureGenerator();
            ICreature creature = generator.GenerateCreature(CreatureTypes.Human);

            ITile currentTile = map.Tiles[0];
            ITile newTile = map.Tiles[1];

            currentTile.CreatureList.Add(creature);

            MoveCreatureActionParameter parameter = new MoveCreatureActionParameter()
            {
                Creature = creature,
                CurrentCreatureTile = currentTile,
                NewCreatureTile = newTile,
            };

            MoveCreatureAction action = new MoveCreatureAction();
            IActionResult result = action.Execute(parameter);

            Assert.IsTrue(result.Success);

            Assert.AreEqual(0, currentTile.CreatureList.Count);
            Assert.AreEqual(1, newTile.CreatureList.Count);

            Assert.IsFalse(currentTile.CreatureList.Contains(creature));
            Assert.IsTrue(newTile.CreatureList.Contains(creature));
        }
    }
}
