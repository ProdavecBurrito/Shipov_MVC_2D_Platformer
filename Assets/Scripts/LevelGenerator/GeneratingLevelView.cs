using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelGenerator
{
    public class GeneratingLevelView : MonoBehaviour
    {
        [SerializeField] private Tilemap _tileMapGround;

        [SerializeField] private Tile _tileGround;

        [SerializeField] private int _mapWidth;

        [SerializeField] private int _mapheight;

        [SerializeField] private int _smoothfactor;

        [Range(0, 100)]
        [SerializeField] private int _randomFillPercent;

        public Tilemap TileMapGround => _tileMapGround;

        public Tile TileGround => _tileGround;

        public int MapWidth => _mapWidth;

        public int MapHeight => _mapheight;

        public int FactorSmooth => _smoothfactor;

        public int RandomFillPercent => _randomFillPercent;
    }
}
