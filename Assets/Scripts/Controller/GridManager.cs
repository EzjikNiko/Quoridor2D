using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile playerTile;

    [SerializeField] private Tile wallTile;

    [SerializeField] private Tile wallPlaceTile;

    [SerializeField] private Transform cam;

    private Tile currentTile;

    private string nameCurrentTile;

    private Dictionary<Vector2, Tile> tiles;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < 17; x++)
        {
            for (int y = 0; y < 17; y++)
            {
                float a = (float)x;
                float b = (float)y;

                if (x % 2 != 0 && y % 2 != 0)
                {
                    currentTile = wallTile;
                    nameCurrentTile = "Wall Tile";
                }
                if (x % 2 == 0 && y % 2 == 0)
                {
                    currentTile = playerTile;
                    nameCurrentTile = "Player Tile";
                }
                if ((x % 2 != 0 && y % 2 == 0) || (x % 2 == 0 && y % 2 != 0))
                {
                    currentTile = wallPlaceTile;
                    nameCurrentTile = "Wall Place Tile";
                }
                var spawnedTile = Instantiate(currentTile, new Vector3(a, b), Quaternion.identity);
                spawnedTile.name = $"{nameCurrentTile} {x} {y}";
                spawnedTile.Init();
                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        cam.transform.position = new Vector3((float)17 / 2 - 0.5f, (float)17 / 2 - 0.5f, -10);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}
