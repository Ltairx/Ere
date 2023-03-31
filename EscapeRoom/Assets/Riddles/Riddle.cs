using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class Riddle : FunctionGettable
{
    public Room room;
    public Degree degree;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (room != null)
        {
            room.AddRiddle(this,degree); 
        }
        else
        {
            Debug.LogError("Riddle: " + gameObject.name + " has missing room reference");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //test method
    private void Move(float posY)
    {
        Vector3 pos = transform.position;
        pos.y = 2 + posY;
        transform.position= pos;
    }


    /// <summary>
    /// when you get the output you need to cast the returned delegate to Action<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="index"></param>
    /// <returns></returns>
    public override Delegate GetFunction(int index)
    {
        
         return ((Action<float>) Move);        
    }

    /// <summary>
    /// function returning how much is the riddle solved.
    /// Used in the game summary, to show 
    /// </summary>
    /// <returns></returns>
    public virtual float GetSolvePercentage()
    {
        return 0f;
    }


    /// <summary>
    /// function which should be called when the riddle is solved.
    /// It's called by the riddle itself!
    /// 
    /// Primarly informs the room of being solved.
    /// </summary>
    protected virtual void OnSolve()
    {
        if (room != null)
        {
            room.RiddleSolved();
        }
    }
}
