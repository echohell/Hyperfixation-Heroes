using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class obstacleTiles : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    private HashSet<Vector3Int> obstacleTilePositions = new HashSet<Vector3Int>();

    private void Awake()
    {
        if (tilemap == null) tilemap = GetComponent<Tilemap>();

        InitializeObstacles();
    }

    private void InitializeObstacles()
    {
        obstacleTilePositions.Clear();

        BoundsInt bounds = tilemap.cellBounds;

        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int i = 0; i < bounds.size.x; i++)
        {
            for (int j = 0; j < bounds.size.y; j++)
            {
                TileBase tile = allTiles[i + j * bounds.size.x];
                if (tile != null)
                {
                    Vector3Int tilePosition = new Vector3Int(bounds.x + i, bounds.y + j, 0);
                    obstacleTilePositions.Add(tilePosition);
                }
            }
        }
    }

    public bool IsTileAnObstacle(Vector2 position)
    {
        Vector3Int gridPos = tilemap.WorldToCell(position);

        return obstacleTilePositions.Contains(gridPos);
    }
}
