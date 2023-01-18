using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisiveTree : Riddle
{
    private int x, y, z;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartSimulating(float notUsedArg)
    {

    }

    void SetX(float x)
    {
        this.x = (int)x;
    }

    void SetY(float y)
    {
        this.y = (int)y;
    }
    void SetZ(float z)
    {
        this.z = (int)z;
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

}
