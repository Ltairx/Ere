using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Tile TILEPREFAB;
    public float TILEWIDTH=0.25f;

    public Vector3 TILEOFFSET = new Vector3(0, 0, 0);

    protected Tile[,] tiles;
    protected int size = 10;


    private int[,] tileSetup = { 
        {-1,19,17,16,15, 18,20,20,20,0 }, 
        {20,19,0 ,20,14, 13,19,19,-1,20}, 
        {11,17,-1,19,-1, 10,17,17,17,10}, 
        {20,11,14,11,13, 10,16,11,11,19}, 
        {-1,-1,-1,-1,-1, 12,14,19,13,18}, 

        {18,19,20,18,14, -1,-1,16,13,13}, 
        {13,15,16,12,15, 12,20,16,11,10}, 
        {11,-1,20,17,16, 18,-1,14,10,-1}, 
        {10,-1,14,17,17, -1,20,15,11,20}, 
        {10,-1,18,20,18, 19,20,19,10,10}        
    };



    // Start is called before the first frame update
    void Start()
    {        
        tiles= new Tile[size,size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                tiles[i, j] = GameObject.Instantiate(TILEPREFAB).GetComponent<Tile>();
                tiles[i, j].SetVal(tileSetup[9-j,i]);
                tiles[i, j].transform.parent= transform;
                tiles[i, j].transform.localScale = new Vector3(TILEWIDTH, TILEWIDTH, TILEWIDTH);
                tiles[i, j].transform.localPosition= new Vector3(i* TILEWIDTH, 0,j* TILEWIDTH) + TILEOFFSET;
                tiles[i, j].transform.localRotation = new Quaternion(0, 0, 0, 0);                

                if(tiles[i,j].GetVal() == -1)
                {                    
                    tiles[i,j].SetMaterial(DIRECTION.CANT_STEP);
                }

            }
        }


    }

    public void ResetMap()
    {
        foreach(var tile in tiles)
        {
            if(tile.GetVal() != -1)
            {
                tile.SetMaterial(DIRECTION.NONE);
            }
            else
            {
                tile.SetMaterial(DIRECTION.CANT_STEP);
            }
        }
    }
    
    public void LightTile(int x, int y, DIRECTION color)
    {
        tiles[x, y].SetMaterial(color);
    }

    public int GetSize()
    {
        return size;
    }

    public int GetTileVal(Vector2 xy)
    {
        return GetTileVal((int)xy.x, (int)xy.y);
    }

    public bool TileLighted(Vector2 xy)
    {
        return TileLighted((int)xy.x, (int)xy.y);
    }

    public bool TileLighted(int x, int y)
    {
        return tiles[x,y].GetLighted();
    }
        public int GetTileVal(int x, int y)
    {
        if(x < 0 || y<0 || x>= size || y >= size)
        {
            return -1; //not exisitng
        }
        else
        {
            return tiles[x, y].GetVal();
        }
    }

}
