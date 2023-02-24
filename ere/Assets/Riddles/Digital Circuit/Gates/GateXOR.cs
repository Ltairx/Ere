using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// MA TYLKO 2 WEJŒCIA
/// </summary>
public class GateXOR : Gate
{
    protected override void CheckInput()
    {
        if(inputs[0].GetOutput() == inputs[1].GetOutput())
        {
            output = false;
            LightOffWires();
        }
        else
        {
            output = true;
            LightWires();
        }
    }
}
