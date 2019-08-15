using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Models.ActionResults
{
    public class MoveCreatureActionResult : IActionResult
    {
        public bool Success { get; set; }
    }
}
