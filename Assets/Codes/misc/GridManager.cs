using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;
    [SerializeField] private GameObject tileHolder;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnTile = Instantiate(tilePrefab,new Vector3(x +.5f,y +.5f),Quaternion.identity);
                spawnTile.name = $"Tile {x} {y}";
                spawnTile.transform.parent = tileHolder.transform;

                var isOffset = (x + y) % 2 == 1;
                spawnTile.Initialize(isOffset);
            }
        }

        cam.transform.position = new Vector3((float) width/2, (float) height/2, -10);
    }
}
