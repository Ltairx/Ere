using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GATENAND : Gate
{
    protected override void CheckInput()
    {
        foreach (SignalSource src in inputs)
        {
            if (src.GetOutput() == false)
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
