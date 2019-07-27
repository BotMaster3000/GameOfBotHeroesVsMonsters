using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Enums;

namespace GameOfBotLib.Models.Items
{
    public class ConsumableItem : IConsumableItem
    {
        public ItemTypes ItemType { get; } = ItemTypes.ConsumableItem;
        public ConsumableItemTypes ConsumableItemType { get; }

        public ConsumableItem(ConsumableItemTypes consumableItemType)
        {
            ConsumableItemType = consumableItemType;
        }

        public static ConsumableItem GetConsumableItem(ConsumableItemTypes consumableItemType)
        {
            return consumableItemType switch
            {
                ConsumableItemTypes.Beer => new ConsumableItem(consumableItemType),
                ConsumableItemTypes.HealingPotion => new ConsumableItem(consumableItemType),
                _ => null
            };
        }
    }
}
