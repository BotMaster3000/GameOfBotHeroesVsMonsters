using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface IAction
    {
        IActionResult Execute(IActionParameter parameter);
    }
}
