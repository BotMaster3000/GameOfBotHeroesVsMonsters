using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Models.ActionParameters;
using GameOfBotLib.Models.ActionResults;

namespace GameOfBotLib.Logic.Actions
{
    public class AttackCreatureAction : IAction
    {
        private const int MaxRoundsPerFight = 1000;

        public IActionResult Execute(IActionParameter parameter)
        {
            IActionResult result = new AttackCreatureActionResult();
            if(parameter is AttackCreatureActionParameter attackParameter)
            {
                ICreature attackingCreature = attackParameter.AttackingCreature;
                ICreature defendingCreature = attackParameter.DefendingCreature;
                int currentRound = 0;
                while(attackingCreature.Health > 0 && defendingCreature.Health > 0 && currentRound < 1000)
                {
                    AttackCreature(attackingCreature, defendingCreature);
                    AttackCreature(defendingCreature, attackingCreature);
                    ++currentRound;
                }
                result.Success = true;
            }
            return result;
        }

        private void AttackCreature(ICreature attackingCreature, ICreature defendingCreature)
        {

        }
    }
}
