using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelGenerator
{
    public class GeneratingLevelController
    {
        private const int CountWall = 4;

        private Tilemap _tileMapGround;
        private Tile _tileGround;
        private int _mapWidth;
        private int _mapHeight;
        private int _smoothFactor;
        private int _randomFillPercent;

        private int[,] _map;

        public GeneratingLevelController(GeneratingLevelView generateLevelView)
        {
            _tileMapGround = generateLevelView.TileMapGround;
            _tileGround = generateLevelView.TileGround;
            _mapWidth = generateLevelView.MapWidth;
            _mapHeight = generateLevelView.MapHeight;
            _smoothFactor = generateLevelView.FactorSmooth;
            _randomFillPercent = generateLevelView.RandomFillPercent;

            _map = new int[_mapWidth, _mapHeight];
        }

        public void AwakeTick()
        {
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            RandomFillLevel();

            for (var i = 0; i < _smoothFactor; i++)
            {
                SmoothMap();
            }

            DrawTilesOnMap();
        }

        private void RandomFillLevel()
        {
            var seed = Time.time.ToString();
            var pseudoRandom = new System.Random(seed.GetHashCode());

            for (var x = 0; x < _mapWidth; x++)
            {
                for (var y = 0; y < _mapHeight; y++)
                {
                    if (x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeight - 1)
                        _map[x, y] = 1;
                    else
                        _map[x, y] = (pseudoRandom.Next(0, 100) < _randomFillPercent) ? 1 : 0;
                }
            }
        }

        private void SmoothMap()
        {
            for (var x = 0; x < _mapWidth; x++)
            {
                for (var y = 0; y < _mapHeight; y++)
                {
                    var neighbourWallTiles = GetSurroundingWallCount(x, y);

                    if (neighbourWallTiles > CountWall)
                        _map[x, y] = 1;
                    else if (neighbourWallTiles < CountWall)
                        _map[x, y] = 0;
                }
            }
        }

        private int GetSurroundingWallCount(int gridX, int gridY)
        {
            var wallCount = 0;

            for (var neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
            {
                for (var neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
                {
                    if (neighbourX >= 0 && neighbourX < _mapWidth && neighbourY >= 0 && neighbourY < _mapHeight)
                    {
                        if (neighbourX != gridX || neighbourY != gridY)
                            wallCount += _map[neighbourX, neighbourY];
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount;
        }

        private void DrawTilesOnMap()
        {
            if (_map == null)
            {
                return;
            }

            for (var x = 0; x < _mapWidth; x++)
            {
                for (var y = 0; y < _mapHeight; y++)
                {
                    var positionTile = new Vector3Int(-_mapWidth / 2 + x, -_mapHeight / 2 + y, 0);

                    if (_map[x, y] == 1)
                    {
                        _tileMapGround.SetTile(positionTile, _tileGround);
                    }
                }
            }
        }
    }
}
