using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelGenerator
{
    public class GeneratingLevelView : MonoBehaviour
    {
        [SerializeField] private Tilemap _tileMapGround;
        [SerializeField] private Tilemap _tileMapWater;

        [SerializeField] private Tile _groundTile;
        [SerializeField] private Tile _waterTile;

        [SerializeField] private int _mapWidth;

        [SerializeField] private int _mapheight;

        [SerializeField] private int _smoothfactor;

        [Range(0, 100)]
        [SerializeField] private int _randomFillPercent;

        public Tilemap TileMapGround => _tileMapGround;
        public Tilemap TileMapWater => _tileMapWater;

        public Tile GroundTile => _groundTile;
        public Tile WaterTile => _waterTile;

        public int MapWidth => _mapWidth;

        public int MapHeight => _mapheight;

        public int FactorSmooth => _smoothfactor;

        public int RandomFillPercent => _randomFillPercent;
    }
}
