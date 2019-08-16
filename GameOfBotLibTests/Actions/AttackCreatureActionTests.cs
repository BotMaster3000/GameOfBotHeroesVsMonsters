using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Logic.Actions;
using GameOfBotLib.Models.ActionParameters;
using GameOfBotLib.Models.ActionResults;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfBotLib.Logic;
using GameOfBotLib.Enums;

namespace GameOfBotLibTests.Actions
{
    [TestClass]
    public class AttackCreatureActionTests
    {
        [TestMethod]
        public void AttackCreatureTest()
        {
            CreatureGenerator generator = new CreatureGenerator();
            ICreature humanCreature = generator.GenerateCreature(CreatureTypes.Human);
            ICreature goblinCreature = generator.GenerateCreature(CreatureTypes.Goblin);

            AttackCreatureActionParameter parameter = new AttackCreatureActionParameter()
            {
                AttackingCreature = humanCreature,
                DefendingCreature = goblinCreature,
            };

            AttackCreatureAction attackAction = new AttackCreatureAction();
            IActionResult result = attackAction.Execute(parameter);
            Assert.IsTrue(result.Success);

            Assert.IsTrue(humanCreature.Health <= 0 || goblinCreature.Health <= 0);
        }
    }
}
