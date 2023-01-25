using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle : MonoBehaviour
{    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //test method
    protected void Move(float posY)
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
    public virtual Delegate GetFunction(int index)
    {
        
         return ((Action<float>) Move);        
    }
}
