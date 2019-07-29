using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Logic;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Models.Creatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfBotLibTests
{
    [TestClass]
    public class CreatureGeneratorTests
    {
        private const int StartingCreatureLevel = 1;
        private const int StartingCreatureExperience = 0;

        [TestMethod]
        public void GenerateCreatureTest_GenerateHuman()
        {
            const int StartingGold = 10;
            const CreatureTypes TypeCreature = CreatureTypes.Human;

            ICreature creature = GetCreature(TypeCreature);

            AssertCreatureIsCorrect(creature, TypeCreature);

            Assert.IsTrue(creature is IHero);

            if (creature is IHero hero)
            {
                Assert.IsNotNull(hero.Inventory);
                Assert.AreEqual(StartingGold, hero.Inventory.Gold);
            }
        }

        [TestMethod]
        public void GenerateCreatureTest_GenerateGoblin()
        {
            const int StartingGold = 5;
            const CreatureTypes TypeCreature = CreatureTypes.Goblin;

            ICreature creature = GetCreature(TypeCreature);
            AssertCreatureIsCorrect(creature, TypeCreature);
            AssertMonsterIsCorrect(creature, StartingGold);
        }

        [TestMethod]
        public void GenerateCreatureTest_GenerateTroll()
        {
            const int StartingGold = 20;
            const CreatureTypes TypeCreature = CreatureTypes.Troll;

            ICreature creature = GetCreature(TypeCreature);
            AssertCreatureIsCorrect(creature, TypeCreature);
            AssertMonsterIsCorrect(creature, StartingGold);
        }
        private ICreature GetCreature(CreatureTypes creatureType)
        {
            CreatureGenerator generator = new CreatureGenerator();
            return generator.GenerateCreature(creatureType);
        }

        private void AssertCreatureIsCorrect(ICreature creature, CreatureTypes creatureType)
        {
            Assert.AreEqual(creatureType, creature.CreatureType);
            Assert.AreEqual(StartingCreatureLevel, creature.Level);
            Assert.AreEqual(StartingCreatureExperience, creature.Experience);
            Assert.IsTrue(creature.Health > 0);
            Assert.AreEqual(creature.Health, creature.MaxHealth);
        }

        private void AssertMonsterIsCorrect(ICreature creature, int startingGold)
        {
            Assert.IsTrue(creature is IMonster);
            if (creature is IMonster monster)
            {
                Assert.IsNotNull(monster.Inventory);
                Assert.AreEqual(startingGold, monster.Inventory.Gold);
            }
        }
    }
}
