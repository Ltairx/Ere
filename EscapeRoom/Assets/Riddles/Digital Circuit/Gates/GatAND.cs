using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatAND : Gate
{    
    protected override void CheckInput()
    {
        foreach (SignalSource src in inputs)
        {
            if (src.GetOutput() == false)
            {
                output = false;
                LightOffWires();
                return;
            }
        }

        //else
        output = true;
        LightWires();
    }
}
