using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// interface for interactable system, to know which function to call.
/// </summary>
public interface GetFunctionInterface
{
    public Delegate GetFunction(int index)
    {
        return null;
        //return ((Action<float>)Move);  //przyk³ad <-  dla funkcji:  private void Move(float posY){}
    }
}
