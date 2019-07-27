using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Enums;

namespace GameOfBotHeroesVsMonsters
{
    public static class MapDrawer
    {
        public static void DrawMap(IMap map)
        {
            ConsoleColor previousConsoleColor = Console.ForegroundColor;
            ConsoleColor previousBackgroundColor = Console.BackgroundColor;
            foreach (ITile tile in map.Tiles)
            {
                Console.CursorLeft = tile.XPos;
                Console.CursorTop = tile.YPos;
                Console.ForegroundColor = GetConsoleColorForTileValue(tile.TileValue);
                Console.BackgroundColor = GetConsoleBackgroundColorForTileValue(tile.TileValue);
                Console.Write('X');
            }
            Console.ForegroundColor = previousConsoleColor;
            Console.BackgroundColor = previousBackgroundColor;
        }

        private static ConsoleColor GetConsoleColorForTileValue(TileValues tileValue)
        {
            return tileValue switch
            {
                TileValues.Forest => ConsoleColor.DarkGreen,
                TileValues.Grassland => ConsoleColor.White,
                TileValues.Fortress => ConsoleColor.Black,
                TileValues.City => ConsoleColor.DarkBlue,
                TileValues.Village => ConsoleColor.DarkRed,
                _ => ConsoleColor.White,
            };
        }

        private static ConsoleColor GetConsoleBackgroundColorForTileValue(TileValues tileValue)
        {
            switch (tileValue)
            {
                case TileValues.Fortress:
                case TileValues.City:
                case TileValues.Village:
                    return ConsoleColor.DarkGray;
                default:
                    return ConsoleColor.Black;
            }
        }
    }
}
