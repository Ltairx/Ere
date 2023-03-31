using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions: MonoBehaviour
{
    public static GameObject Base;
    public static GameObject Arm1;
    public static GameObject Arm2;
    public static GameObject Finger1;
    public static GameObject Finger2;
    public static GameObject Wrist;
    protected float val;
    protected bool finished;
    protected float duration = 1.0f;

    public void setval(float val)
    {
        this.val = val;
    }
    protected IEnumerator command()
    {
        finished = false;
        float startTime = Time.time;
        float percentage = 0;
        while (Time.time < startTime + duration)
        {
            percentage = (Time.time - startTime) / duration;
            busy(percentage);
            yield return null;
        }
        busy(1f);
        finished = true;
    }
    public virtual void Run()
    {
        StartCoroutine(command());
    }
    public bool Finished()
    {
        return finished;
    }
    protected virtual void busy(float perc){}
}
