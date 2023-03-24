using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// jest to bardzo g�upie ale dzia�a.
/// �r�d�o synga�u dziedziczy po zagadce przez udost�pnianie i tak ju� publicznej metody setinput.
/// Ale nie chcia�em modyfikowa� jako� dziwnie kodu d�wigni, a w�asciwie samej klasy bazowej Interactable.
/// </summary>
public class SignalSource : FunctionGettable 
{
    protected bool output = false;
    public Wire[] childWires;

    public void SetInput(bool val)
    {
        output = val;
        if (output)
        {
            LightWires();
        }
        else
        {
            LightOffWires();
        }
    }


    public bool GetOutput() { 
        return output; 
    }


    public override Delegate GetFunction(int index)
    {
        return ((Action<bool>)SetInput);
    }


    protected void LightWires()
    {
        foreach(Wire wire in childWires)
        {
            wire.Light();
        }   
    }
    protected void LightOffWires()
    {
        foreach (Wire wire in childWires)
        {
            wire.LightOff();
        }
    }
}
