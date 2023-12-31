using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    // [SerializeField] private Transform cam;
    [SerializeField] private GameObject tileHolder;

    public void DumpGrid()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnTile = Instantiate(tilePrefab,new Vector3(x -15.5f,y -15.5f),Quaternion.identity);
                spawnTile.name = $"Tile {x} {y}";
                spawnTile.transform.parent = tileHolder.transform;

                var isOffset = (x + y) % 2 == 1;
                spawnTile.Initialize(isOffset);
            }
        }

        // cam.transform.position = new Vector3((float) width/2, (float) height/2, -10);
    }

    public void SetActive(bool b)
    {
        gameObject.SetActive(b);
    }
}
