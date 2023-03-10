using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// interface for interactable system, to know which function to call.
/// </summary>
public interface GetFunctionInterface
{
    Delegate GetFunction(int index);
    
    
}
