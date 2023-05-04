using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fingers : Instructions
{
    //public AudioClip sfx_1;
    Vector3 startRot;
    Vector3 endRot;
    Vector3 startRot2;
    Vector3 endRot2;
    private const float c_value = 0.00085f;
    private float value = c_value;
    private static bool open = true;

    private void Start()
    {
        //duration = 1f;
        if(this.val == 0)
        {
            value = c_value;
        }
        else
        {
            value = -c_value;
        }
    }

    protected override void Busy(float perc)
    {
        Finger1.transform.localPosition = Vector3.Lerp(startRot, endRot, perc);
        Finger2.transform.localPosition = Vector3.Lerp(startRot2, endRot2, perc);
    }
    public override void Run()
    {
        if (src1 != null && fingers_sound != null)
        {
            src1.clip = fingers_sound;
            src1.Play();
        }
        if (this.val == 0 && open)
        {
            Grabber.grabbed = true;
            open = false;
        }
        else if (this.val == 1 && !open)
        {
            if (!Grabber.check_child)
            {
                Grabber.grabbed = false;
                open = true;
            }
            else if (trans_value == 40)
            {
                Grabber.grabbed = false;
                open = true;
            }
            else value = 0;
        }
        else value = 0;
        startRot = Finger1.transform.localPosition;
        endRot = startRot + new Vector3(value, 0, 0); //transposition of finger1
        startRot2 = Finger2.transform.localPosition;
        endRot2 = startRot2 + new Vector3(-value, 0, 0); //transposition of finger2
        base.Run();
    }
    protected override void ReverseBusy(float perc)
    {
        Finger1.transform.localPosition = Vector3.Lerp(startRot, endRot, perc);
        Finger2.transform.localPosition = Vector3.Lerp(startRot2, endRot2, perc);
    }
    public override void ReverseRun()
    {
        if (src1 != null && fingers_sound != null)
        {
            src1.clip = fingers_sound;
            src1.Play();
        }
        if (value == c_value)
        {
            Grabber.grabbed = false;
            open = true;
        }
        else if (value == -c_value)
        {
            Grabber.grabbed = true;
            open = false;
        }
        startRot = Finger1.transform.localPosition;
        endRot = startRot + new Vector3(-value, 0, 0); //transposition of finger1
        startRot2 = Finger2.transform.localPosition;
        endRot2 = startRot2 + new Vector3(value, 0, 0); //transposition of finger2
        base.Run();
    }
}
