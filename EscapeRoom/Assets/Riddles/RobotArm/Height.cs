using System;
using UnityEngine;

public class Height : Instructions
{
    private Quaternion startRot;
    private Quaternion endRot;
    private Quaternion startRot2;
    private Quaternion endRot2;
    private Quaternion startRot3;
    private Quaternion endRot3;

    private float val_reverse = 0;
    private void Start()
    {
        //duration = 1f;
    }
    protected override void Busy(float perc)
    {
        Arm1.transform.localRotation = Quaternion.Lerp(startRot, endRot, perc);
        Arm2.transform.localRotation = Quaternion.Lerp(startRot2, endRot2, perc);
        Wrist.transform.localRotation = Quaternion.Lerp(startRot3, endRot3, perc);
    }
    public override void Run() 
    {
        if (trans_value + val < 0)
        {
            val = -trans_value;
            trans_value = 0;
        }
        else if (trans_value + val > 40)
        {
            val = 40 - trans_value;
            trans_value = 40;
        }
        else trans_value += val;
        val_reverse = val;
        startRot = Arm1.transform.localRotation;
        endRot = startRot * Quaternion.Euler(val, 0, 0);
        startRot2 = Arm2.transform.localRotation;
        endRot2 = startRot2 * Quaternion.Euler(2 * val, 0, 0); //rotation of arm2
        startRot3 = Wrist.transform.localRotation;
        endRot3 = startRot3 * Quaternion.Euler(0, 0, 0); //rotation of wrist
        base.Run();
    }
    protected override void ReverseBusy(float perc)
    {
        Arm1.transform.localRotation = Quaternion.Lerp(startRot, endRot, perc);
        Arm2.transform.localRotation = Quaternion.Lerp(startRot2, endRot2, perc);
        Wrist.transform.localRotation = Quaternion.Lerp(startRot3, endRot3, perc);
    }
    public override void ReverseRun()
    {
        trans_value -= val_reverse;
        startRot = Arm1.transform.localRotation;
        endRot = startRot * Quaternion.Euler(-val_reverse, 0, 0);
        startRot2 = Arm2.transform.localRotation;
        endRot2 = startRot2 * Quaternion.Euler(-2 * val_reverse, 0, 0); //rotation of arm2
        startRot3 = Wrist.transform.localRotation;
        endRot3 = startRot3 * Quaternion.Euler(0, 0, 0); //rotation of wrist
        base.ReverseRun();
    }
}
