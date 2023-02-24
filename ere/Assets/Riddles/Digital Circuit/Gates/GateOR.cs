using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOR : Gate
{
    protected override void CheckInput()
    {
        foreach(SignalSource src in inputs)
        {
            if(src.GetOutput() == true)
            {
                output = true;
                LightWires();
                return;
            }
        }

        //else
        output = false;
        LightOffWires();
    }
}
