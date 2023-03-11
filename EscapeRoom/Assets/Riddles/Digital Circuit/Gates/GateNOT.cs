using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateNOT : Gate
{
    protected override void CheckInput()
    {        
        output = !inputs[0].GetOutput();
     
        if (output)
        {
            LightWires();
        }
        else
        {
            LightOffWires();
        }
    }
}
