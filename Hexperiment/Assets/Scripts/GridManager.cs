using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public GameObject TilePrefab;
    public int GridWidth, GridHeight;
    public double TileScale;
    private GridSpace[,] Grid; 

	// Use this for initialization
	void Start () {
        GridGen(GridWidth, GridHeight);
        foreach (GridSpace tile in Grid)
        {
            tile.SetTile(Instantiate(TilePrefab));

        }
	}

    private void GridGen(int pGridWidth, int pGridHeight)
    {
        Grid = new GridSpace[pGridWidth, pGridHeight];
        for (int i = 0; i < pGridWidth; i++)
        {
            for (int j = 0; j < pGridHeight; j++)
            {
                Grid[i, j] = new GridSpace(i, j, pTileSize: TileScale);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

public class GridSpace
{
    private int X, Y, H;
    private double TileSize;
    private GameObject Tile;

    public int Z()
    {
        return 0 - X - Y;
    }

    public GridSpace(int pPosX, int pPosY, int pPosH = 0, double pTileSize = 1)
    {
        X = pPosX;
        Y = pPosY;
        H = pPosH;

        TileSize = pTileSize;
    }

    public void SetTile(GameObject pTileObject)
    {
        float Xpos = (float)((X * TileSize * 0.5) + (Z() * -TileSize * 0.5));
        float ZPos = (float)(Y * TileSize * 0.75);

        Tile = pTileObject;
        Tile.transform.position = new Vector3(Xpos, 1, ZPos);
        
    }
}
