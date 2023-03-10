using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateNOR : Gate
{
    protected override void CheckInput()
    {
        foreach (SignalSource src in inputs)
        {
            if (src.GetOutput() == true)
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
