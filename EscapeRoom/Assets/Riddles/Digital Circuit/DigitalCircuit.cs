using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitalCircuit : Riddle
{
    public Wire chapter1, chapter2, chapter3, chapter4;
    bool chapter1WasOn = false, chapter2WasOn = false, chapter3WasOn = false, chapter4WasOn = false;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 0.5f)
        {
            if (!chapter1WasOn && chapter1.IsOn()) chapter1WasOn = true;
            if (!chapter2WasOn && chapter2.IsOn()) chapter2WasOn = true;
            if (!chapter3WasOn && chapter3.IsOn()) chapter3WasOn = true;
            if (!chapter4WasOn && chapter4.IsOn()) chapter4WasOn = true;
        }
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
