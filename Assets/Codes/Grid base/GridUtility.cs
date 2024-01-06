using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUtility : MonoBehaviour
{
    public static Vector2Int WorldtoGridSnap(Vector2 worldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt(worldPosition.x), Mathf.FloorToInt(worldPosition.y));
    }

    public static Vector2 GridSnaptoWorld(Vector2 gridPosition)
    {
        return new Vector2(gridPosition.x, gridPosition.y);
    }
}
