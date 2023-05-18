using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisiveTree : Riddle
{
    public Tree tree;
    public Map map;

    public float simulationDelay=1f;

    Vector2 pos;

    private int x=20, y= 20, z= 20;
    private int simX= 20, simY= 20, simZ= 20;


    protected bool simulating = false;
    protected bool riddleTouched = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Start()
    {
        base.Start();
        map.Initialize();
    }

    void StartSimulating(float notUsedArg)
    {
        riddleTouched = true;
        if (!simulating)
        {
            simX = x;
            simY = y;
            simZ = z;
            map.ResetMap();
            StartCoroutine(Simulate());
        }
    }


    protected IEnumerator Simulate()
    {
        bool canMove = true;
        simulating = true;
        float lastFrame=0;

        pos = Vector2.zero;        
        while (canMove)
        {
            if(Time.time > lastFrame + simulationDelay)
            {
                lastFrame = Time.time;

                if (map.TileLighted(pos))
                {
                    canMove = false;
                    break;
                }

                switch (CalcDirection(map.GetTileVal(pos)))
                {
                    case DIRECTION.NORTH:                        
                        tree.LightTree(DIRECTION.NORTH);
                        map.LightTile((int)pos.x,(int)pos.y, DIRECTION.NORTH);
                        pos.y += 1;
                        break;
                    case DIRECTION.WEST:                        
                        tree.LightTree(DIRECTION.WEST);
                        map.LightTile((int)pos.x, (int)pos.y, DIRECTION.WEST);
                        pos.x -= 1;
                        break;
                    case DIRECTION.EAST:                        
                        tree.LightTree(DIRECTION.EAST);
                        map.LightTile((int)pos.x, (int)pos.y, DIRECTION.EAST);
                        pos.x += 1;
                        break;
                    case DIRECTION.SOUTH:                        
                        tree.LightTree(DIRECTION.SOUTH);
                        map.LightTile((int)pos.x, (int)pos.y, DIRECTION.SOUTH);
                        pos.y -= 1;
                        break;
                    case DIRECTION.CANT_STEP:                        
                        canMove = false;
                        break;
                }

                map.LightTile((int)pos.x, (int)pos.y, DIRECTION.ACTUAL_POS);


                if (pos.x == 9 && pos.y == 9)
                {
                    break;
                }         
            }

            yield return null; 
        }

        if (canMove)
        {
            Debug.Log("DECISIVE TREE SOLVED");
            //riddle solved!
            this.OnSolve();
        }        
        simulating = false;

    }


    protected DIRECTION CalcDirection(int tileVal)
    {       
        if(tileVal == -1) { return DIRECTION.CANT_STEP; }

        if(tileVal <= simX)
        {
            if (tileVal <= simY)
            {
                tree.LightTree(DIRECTION.NORTH);
                return DIRECTION.NORTH;
            }
            else
            {
                tree.LightTree(DIRECTION.SOUTH);
                return DIRECTION.SOUTH;
            }
        }
        else
        {
            if (tileVal <= simZ)
            {
                tree.LightTree(DIRECTION.WEST);
                return DIRECTION.WEST;
            }
            else
            {
                tree.LightTree(DIRECTION.EAST);
                return DIRECTION.EAST;
            }
        }        
    }

    void SetX(float x)
    {        
        this.x = (int)x;
        tree.SetX(this.x);
    }

    void SetY(float y)
    {
        this.y = (int)y;
        tree.SetY(this.y);
    }
    void SetZ(float z)
    {
        this.z = (int)z;
        tree.SetZ(this.z);
    }



    public override Delegate GetFunction(int index)
    {        
        switch (index)
        {
            case 0:
                return (Action<float>) StartSimulating;
            case 1:
                return (Action<float>)SetX;
            case 2:
                return (Action<float>)SetY;
            case 3:
                return (Action<float>)SetZ;
            default:
                return (Action<float>)StartSimulating;
        }
    }

    /// <summary>
    /// ideal answer:
    /// x=18
    /// y=21
    /// z=22
    /// 
    /// result accordingly to the distance to the destination point
    /// </summary>
    /// <returns></returns>
    public override float GetSolvePercentage()
    {
        if (!riddleTouched)
        {
            float distance = Math.Max(map.GetSize() - 1 - pos.x, map.GetSize() - 1 - pos.y);
            float maxDistance = 5f;
            if (distance <= 5f)
            {
                return 1 - distance / maxDistance;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

}
