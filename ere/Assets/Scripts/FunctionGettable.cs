using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionGettable : MonoBehaviour,GetFunctionInterface
{
    public virtual Delegate GetFunction(int index)
    {

        return null;
    }
}
