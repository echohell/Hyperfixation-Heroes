using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;                                                                                 // calls on tilemap

public class TileSelect : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;                                                               // set a background interactable tile map
    [SerializeField] private Tilemap obstaclesmap;                                                          // set an obstacle map
    [SerializeField] private float offset = .5f;                                                            // set the offset value in selecting tiles
    [SerializeField] private Vector2 gridSize = new Vector2(1f, 1f);                                        // set base grid values of vec2

    private Vector2Int highlightTilePos = Vector2Int.zero;                                                  // set highlighting tile pos (sword)

    private void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2Int gridPos = new Vector2Int (
            Mathf.FloorToInt(mouseWorldPosition.x / gridSize.x) * Mathf.RoundToInt(gridSize.x),
            Mathf.FloorToInt(mouseWorldPosition.y / gridSize.y) * Mathf.RoundToInt(gridSize.y)
        );

        bool isObstacleTile = false;
        if (obstaclesmap != null)
        {
            Vector3Int cellPosition = obstaclesmap.WorldToCell(mouseWorldPosition);
            if (obstaclesmap.HasTile(cellPosition) && obstaclesmap.GetTile(cellPosition) != null)
            {
                isObstacleTile = true;
            }
        }

        if (!isObstacleTile)
        {
            highlightTilePos = gridPos;
            Vector2 worldPos = GridUtility.GridSnaptoWorld(gridPos) + new Vector2(offset, offset);
            transform.position = worldPos;
        }
    }

    public Vector2Int HighlightTilePos { get { return highlightTilePos; } }

    public bool isHighlightedTileClicked(Vector2 clickPos)
    {
        Vector2Int gridPos = GridUtility.WorldtoGridSnap(clickPos);
        return gridPos == highlightTilePos;
    }

    public Vector2 GetHighlightTilePos() { return GridUtility.GridSnaptoWorld(highlightTilePos); }

    public bool IsTileAnObstacle(Vector2Int position)
    {
        Vector3 worldPosition = GridUtility.GridSnaptoWorld(position);
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
