using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : Instructions
{
    //public AudioClip sfx_2;
    Quaternion startRot;
    Quaternion endRot;
    private void Start()
    {
        //duration = 1f;
    }
    protected override void Busy(float perc)
    {
        Base.transform.localRotation = Quaternion.Lerp(startRot, endRot, perc);
    }
    public override void Run()
    {
        if (src1 != null && base_sound != null)
        {
            src1.clip = base_sound;
            src1.Play();
        }
        startRot = Base.transform.localRotation;
        endRot = startRot * Quaternion.Euler(0, val, 0); //rotation of base
        base.Run();
    }
    protected override void ReverseBusy(float perc)
    {
        Base.transform.localRotation = Quaternion.Lerp(startRot, endRot, perc);
    }
    public override void ReverseRun()
    {
        if (src1 != null && base_sound != null)
        {
            src1.clip = base_sound;
            src1.Play();
        }
        startRot = Base.transform.localRotation;
        endRot = startRot * Quaternion.Euler(0, -val, 0);
        base.ReverseRun();
    }
}
