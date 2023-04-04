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

    private float value;
    private void Start()
    {
        //duration = 1f;
    }
    protected override void busy(float perc)
    {
        Arm1.transform.localRotation = Quaternion.Lerp(startRot, endRot, perc);
        Arm2.transform.localRotation = Quaternion.Lerp(startRot2, endRot2, perc);
        Wrist.transform.localRotation = Quaternion.Lerp(startRot3, endRot3, perc);
    }
    public override void Run()
    {
        startRot = Arm1.transform.localRotation;
        endRot = startRot * Quaternion.Euler(val, 0, 0);
        startRot2 = Arm2.transform.localRotation;
        endRot2 = startRot2 * Quaternion.Euler(2 * val, 0, 0); //rotation of arm2
        startRot3 = Wrist.transform.localRotation;
        endRot3 = startRot3 * Quaternion.Euler(0, 0, 0); //rotation of wrist
        base.Run();
    }
    protected override void reverse_busy(float perc)// tu w ogóle nie wchodzi program
    {
        Arm1.transform.localRotation = Quaternion.Lerp(startRot, endRot, perc);
        Arm2.transform.localRotation = Quaternion.Lerp(startRot2, endRot2, perc);
        Wrist.transform.localRotation = Quaternion.Lerp(startRot3, endRot3, perc);
    }
    public override void Reverse_run()
    {
        startRot = Arm1.transform.localRotation;
        endRot = startRot * Quaternion.Euler(-val, 0, 0);
        startRot2 = Arm2.transform.localRotation;
        endRot2 = startRot2 * Quaternion.Euler(-2 * val, 0, 0); //rotation of arm2
        startRot3 = Wrist.transform.localRotation;
        endRot3 = startRot3 * Quaternion.Euler(0, 0, 0); //rotation of wrist
        base.Reverse_run();
    }
}
