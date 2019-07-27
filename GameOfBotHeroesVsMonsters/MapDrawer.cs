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
            foreach(ITile tile in map.Tiles)
            {
                Console.CursorLeft = tile.XPos;
                Console.CursorTop = tile.YPos;
                Console.ForegroundColor = GetConsoleColorForTileValue(tile.TileValue);
                Console.Write('X');
            }
            Console.ForegroundColor = previousConsoleColor;
        }

        private static ConsoleColor GetConsoleColorForTileValue(TileValues tileValue)
        {
            return tileValue switch
            {
                TileValues.Forest => ConsoleColor.DarkGreen,
                TileValues.Grassland => ConsoleColor.DarkYellow,
                TileValues.Fortress => ConsoleColor.DarkGray,
                TileValues.City => ConsoleColor.DarkBlue,
                TileValues.Village => ConsoleColor.DarkRed,
                _ => ConsoleColor.White,
            };
        }
    }
}
