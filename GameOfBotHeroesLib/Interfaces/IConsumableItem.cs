using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Interfaces
{
    public interface IConsumableItem : IItem
    {
        ConsumableItemTypes ConsumableItemType { get; }
    }
}
