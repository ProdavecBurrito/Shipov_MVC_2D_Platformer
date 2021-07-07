using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelGenerator
{
    public class GeneratingLevelController
    {
        private const int NOTHING_NUMBER = 0;
        private const int GROUND_NUMBER = 1;
        private const int WATER_NUMBER = 2;
        private const int X_EXIT = 6;
        private const int Y_EXIT = 7;

        private const int GroundBlocksCount = 4;

        private Tilemap _tileMapGround;
        private Tilemap _tileMapWater;

        private Tile _groundTile;
        private Tile _waterTile;

        private int _mapWidth;
        private int _mapHeight;
        private int _smoothFactor;
        private int _randomFillPercent;

        private int[,] _map;

        public GeneratingLevelController(GeneratingLevelView generateLevelView)
        {
            _tileMapGround = generateLevelView.TileMapGround;
            _tileMapWater = generateLevelView.TileMapWater;
            _groundTile = generateLevelView.GroundTile;
            _waterTile = generateLevelView.WaterTile;
            _mapWidth = generateLevelView.MapWidth;
            _mapHeight = generateLevelView.MapHeight;
            _smoothFactor = generateLevelView.FactorSmooth;
            _randomFillPercent = generateLevelView.RandomFillPercent;

            _map = new int[_mapWidth, _mapHeight];
        }

        public void StartGeneration()
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
            var randomTile = new System.Random();

            for (var x = 0; x < _mapWidth; x++)
            {
                for (var y = 0; y < _mapHeight; y++)
                {
                    if (x == X_EXIT && y == _mapHeight - 1 || x == 0 && y == Y_EXIT)
                    {
                        _map[x, y] = NOTHING_NUMBER;
                    }
                    else if (x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeight - 1)
                    {
                        _map[x, y] = GROUND_NUMBER;
                    }
                    else
                    {
                        if (pseudoRandom.Next(0, 100) < _randomFillPercent)
                        {
                            if (randomTile.Next(GROUND_NUMBER, 3) == GROUND_NUMBER)
                            {
                                _map[x, y] = GROUND_NUMBER;
                            }
                            else
                            {
                                _map[x, y] = WATER_NUMBER;
                            }
                        }

                    }
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

                    if (neighbourWallTiles > GroundBlocksCount)
                    {
                        _map[x, y] = GROUND_NUMBER;
                    }
                    else if (neighbourWallTiles < GroundBlocksCount)
                    {
                        _map[x, y] = NOTHING_NUMBER;
                    }
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
                        {
                            wallCount += _map[neighbourX, neighbourY];
                        }
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

                    if (_map[x, y] == GROUND_NUMBER)
                    {
                        _tileMapGround.SetTile(positionTile, _groundTile);
                    }

                    if (_map[x,y] == WATER_NUMBER)
                    {
                        _tileMapWater.SetTile(positionTile, _waterTile);
                    }
                }
            }
        }
    }
}
