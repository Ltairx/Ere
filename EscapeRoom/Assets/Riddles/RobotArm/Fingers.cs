using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fingers : Instructions
{
    Vector3 startRot;
    Vector3 endRot;
    Vector3 startRot2;
    Vector3 endRot2;
    private float value = 0.00085f;

    private void Start()
    {
        //duration = 1f;
        if(this.val == 0)
        {
            value = Mathf.Abs(value);
        }
        else
        {
            value = -1* Mathf.Abs(value);
        }
    }

    protected override void busy(float perc)
    {
        Finger1.transform.localPosition = Vector3.Lerp(startRot, endRot, perc);
        Finger2.transform.localPosition = Vector3.Lerp(startRot2, endRot2, perc);
    }
    public override void Run()
    {   
        if(this.val == 0) 
        {
            Grabber.grabbed = true;
        }
        else
        {
            Grabber.grabbed = false;
        }
        startRot = Finger1.transform.localPosition;
        endRot = startRot + new Vector3(value, 0, 0); //transposition of finger1
        startRot2 = Finger2.transform.localPosition;
        endRot2 = startRot2 + new Vector3(-value, 0, 0); //transposition of finger2
        base.Run();
    }
    protected override void reverse_busy(float perc)// tu w ogóle nie wchodzi program
    {
        Finger1.transform.localPosition = Vector3.Lerp(startRot, endRot, perc);
        Finger2.transform.localPosition = Vector3.Lerp(startRot2, endRot2, perc);
    }
    public override void Reverse_run()
    {
        if (this.val == 0)
        {
            Grabber.grabbed = false;
        }
        else
        {
            Grabber.grabbed = true;
        }
        startRot = Finger1.transform.localPosition;
        endRot = startRot + new Vector3(-value, 0, 0); //transposition of finger1
        startRot2 = Finger2.transform.localPosition;
        endRot2 = startRot2 + new Vector3(value, 0, 0); //transposition of finger2
        base.Run();
    }
}
