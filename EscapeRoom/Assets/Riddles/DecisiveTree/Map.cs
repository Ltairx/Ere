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
        {-1,23,23,19,-1, 23,25,25,25,0 }, 
        {25,15,-1,25,25, 18,-1,24,-1,25}, 
        {16,15,-1,24,-1, 15,-1,-1,-1,15}, 
        {25,18,22,22,22, 22,-1,19,22,24}, 
        {-1,-1,-1,-1,-1, 17,22,22,18,23}, 

        {23,24,25,23,19, -1,-1,-1,18,18}, 
        {18,20,-1,17,20, 17,25,21,16,15}, 
        {16,-1,25,22,21, 23,-1,19,15,-1}, 
        {15,-1,19,22,22, -1,25,20,16,25}, 
        {15,-1,23,25,23, 24,25,24,15,15}        
    };
    /*
    private int[,] tileSetup = {
        {-1,24,22,21,20, 23,25,25,25,0 },
        {25,24,0 ,25,19, 18,24,24,-1,25},
        {16,22,-1,24,-1, 15,22,22,22,15},
        {25,16,19,16,18, 15,21,16,16,24},
        {-1,-1,-1,-1,-1, 17,19,24,18,23},

        {23,24,25,23,19, -1,-1,21,18,18},
        {18,20,21,17,20, 17,25,21,16,15},
        {16,-1,25,22,21, 23,-1,19,15,-1},
        {15,-1,19,22,22, -1,25,20,16,25},
        {15,-1,23,25,23, 24,25,24,15,15}
    };
    */

    /*
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
    */


    public void Initialize()
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
        if(x>=0 && y>=0 && x< size && y< size)
        {
            tiles[x, y].SetMaterial(color);
        }
        else
        {
            if (x < 0)
            {
                tiles[x+1, y].SetMaterial(color);
            }
            else if (x >= size)
            {
                tiles[x-1, y].SetMaterial(color);
            }
            else if(y<0)
            {
                tiles[x, y+1].SetMaterial(color);
            }
            else
            {
                tiles[x, y-1].SetMaterial(color);
            }
        }
        
    }

    public int GetSize()
    {
        return size;
    }

    public int GetTileVal(Vector2 xy)
    {
        if (xy.x >= 0 && xy.y >= 0)
        {
            return GetTileVal((int)xy.x, (int)xy.y);
        }
        else
        {
            return -1;
        }
    }

    public bool TileLighted(Vector2 xy)
    {
        if (xy.x < 0 || xy.y < 0 || xy.x >= size || xy.y >= size)
        {
            return false; //not exisitng
        }
        else
        {
            return TileLighted((int)xy.x, (int)xy.y);
        }
        
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
