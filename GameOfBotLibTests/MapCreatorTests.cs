using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GameOfBotLib.Logic;
using GameOfBotLib.Enums;
using GameOfBotLib.Interfaces;
using System.Linq;

namespace GameOfBotLibTests
{
    [TestClass]
    public class MapCreatorTests
    {
        [TestMethod]
        public void MapCreatorGenerateFlatMapTest()
        {
            const int MapWidth = 100;
            const int MapHeight = 100;

            Dictionary<TileValues, int> tileValueAndAppearanceChance = new Dictionary<TileValues, int>()
            {
                { TileValues.City, 10 },
                { TileValues.Forest, 10 },
            };

            MapCreator creator = new MapCreator();
            IMap map = creator.GenerateFlatMap(MapWidth, MapHeight, tileValueAndAppearanceChance);

            Assert.AreEqual(MapWidth, map.Width);
            Assert.AreEqual(MapHeight, map.Height);

            int cityTilesCount = CountMapTilesOfGivenTileValue(map, TileValues.City);
            int forestTileCount = CountMapTilesOfGivenTileValue(map, TileValues.Forest);

            Assert.IsTrue(cityTilesCount * 1.0 / map.Tiles.Length >= 0.4); // Should be at least 40% for equal chances of generation
            Assert.IsTrue(forestTileCount * 1.0 / map.Tiles.Length >= 0.4);

            for (int xPos = 0; xPos < MapWidth; ++xPos)
            {
                for (int yPos = 0; yPos < MapHeight; ++yPos)
                {
                    int tempXPos = xPos; // Needed because of lambda-creation and tight loops
                    int tempYPos = yPos;

                    System.Threading.Tasks.Task.Factory.StartNew(() =>
                    {
                        Assert.AreEqual(1,
                        map.Tiles.Count(x
                        => x.XPos == tempXPos
                        && x.YPos == tempYPos)); // Should contain every XPos and YPos exactly 1 time
                    });
                }
            }
        }

        private int CountMapTilesOfGivenTileValue(IMap map, TileValues tileValue)
        {
            return map.Tiles.Count(x => x.TileValue == tileValue);
        }
    }
}
