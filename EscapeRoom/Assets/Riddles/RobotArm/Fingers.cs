using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Fingers : Instructions
{
    Vector3 startRot;
    Vector3 endRot;
    Vector3 startRot2;
    Vector3 endRot2;
    float value = 0.00085f; 

    private void Start()
    {
        //duration = 1f;
        //if(this.val == 0)
        //{
        //    value = -1 * Mathf.Abs(value);
        //}
        //else
        //{
        //    value = Mathf.Abs(value);
        //}
    }

    protected override void busy(float perc)
    {
        Finger1.transform.localPosition = Vector3.Lerp(startRot, endRot, perc);
        Finger2.transform.localPosition = Vector3.Lerp(startRot2, endRot2, perc);
    }
    public override void Run()
    {
        startRot = Finger1.transform.localPosition;
        endRot = startRot + new Vector3(value, 0, 0); //rotation of finger1
        startRot2 = Finger2.transform.localPosition;
        endRot2 = startRot2 + new Vector3(-value, 0, 0); //rotation of finger2

    }
}
