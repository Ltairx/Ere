using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : Instructions
{
    Quaternion startRot;
    Quaternion endRot;
    private void Start()
    {
        //duration = 1f;
    }
    protected override void busy(float perc)// tu w ogóle nie wchodzi program
    {
        Base.transform.localRotation = Quaternion.Lerp(startRot, endRot, perc);
    }
    public override void Run()
    {
        startRot = Base.transform.localRotation;
        endRot = startRot * Quaternion.Euler(0, val, 0); //rotation of base
        base.Run();
        Debug.Log((startRot, endRot));
    }
}
