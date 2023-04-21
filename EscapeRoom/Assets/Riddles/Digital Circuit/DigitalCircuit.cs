using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitalCircuit : Riddle
{
    public Wire chapter1, chapter2, chapter3, chapter4;
    bool chapter1WasOn, chapter2WasOn, chapter3WasOn, chapter4WasOn;

    // Update is called once per frame
    void Update()
    {
        if (!chapter1WasOn && chapter1.on) chapter1WasOn = true;
        if (!chapter2WasOn && chapter2.on) chapter2WasOn = true;
        if (!chapter3WasOn && chapter3.on) chapter3WasOn = true;
        if (!chapter4WasOn && chapter4.on) chapter4WasOn = true;
    }

    public override float GetSolvePercentage()
    {
        if (chapter4WasOn)
        {
            return 1;
        }
        else
        {
            if (chapter3WasOn)
            {
                return 0.6f;
            }
            else
            {
                if (chapter2WasOn)
                {
                    return 0.3f;
                }
                else
                {
                    if (chapter1WasOn)
                    {
                        return 0.1f;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }        
    }
}
