using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : SignalSource
{
    public SignalSource[] inputs;    
    
    private void Update()
    {
        CheckInput();
    }

    protected virtual void CheckInput() {}    

}
