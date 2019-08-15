using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Models.ActionParameters;
using GameOfBotLib.Models.ActionResults;

namespace GameOfBotLib.Logic.Actions
{
    public class MoveCreatureAction : IAction
    {
        public IActionResult Execute(IActionParameter parameter)
        {
            MoveCreatureActionResult result = new MoveCreatureActionResult();
            if(parameter is MoveCreatureActionParameter moveParameter)
            {
                moveParameter.CurrentCreatureTile.CreatureList.Remove(moveParameter.Creature);
                moveParameter.NewCreatureTile.CreatureList.Add(moveParameter.Creature);
                result.Success = true;
            }
            else
            {
                result.Success = false;
            }
            return result;
        }
    }
}
