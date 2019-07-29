using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Models.Creatures;

namespace GameOfBotLib.Logic
{
    public class CreatureGenerator : ICreatureGenerator
    {
        private static int creatureID = 0;

        private readonly Dictionary<CreatureTypes, int> creatureTypeAndStartingHealth = new Dictionary<CreatureTypes, int>()
        {
            { CreatureTypes.Human , 100 },
            { CreatureTypes.Goblin, 10 },
            { CreatureTypes.Troll, 200 },
        };

        private readonly Dictionary<CreatureTypes, int> creatureTypeAndStartingGold = new Dictionary<CreatureTypes, int>()
        {
            { CreatureTypes.Human , 10 },
            { CreatureTypes.Goblin, 5 },
            { CreatureTypes.Troll, 20 },
        };

        public ICreature GenerateCreature(CreatureTypes creatureType)
        {
            int startingHealth = creatureTypeAndStartingHealth[creatureType];
            int startingGold = creatureTypeAndStartingGold[creatureType];

            ICreature creature;
            switch (creatureType)
            {
                case CreatureTypes.Human:
                    Hero hero = new Hero(creatureType, startingHealth, startingHealth, GetNextCreatureID());
                    hero.Inventory.AddGold(startingGold);
                    creature = hero;
                    break;
                case CreatureTypes.Goblin:
                case CreatureTypes.Troll:
                    Monster monster = new Monster(creatureType, startingHealth, startingHealth, GetNextCreatureID());
                    monster.Inventory.AddGold(startingGold);
                    creature = monster;
                    break;
                default:
                    return null;
            }
            return creature;
        }

        public ICreature[] GenerateCreatures(CreatureTypes creatureType, int amount)
        {
            throw new NotImplementedException();
        }

        private static int GetNextCreatureID()
        {
            return ++creatureID;
        }
    }
}
