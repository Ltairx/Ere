using System.Collections;
using UnityEngine;

public class Instructions: MonoBehaviour
{
    public static GameObject Base;
    public static GameObject Arm1;
    public static GameObject Arm2;
    public static GameObject Finger1;
    public static GameObject Finger2;
    public static GameObject Wrist;
    protected static float trans_value = 0;
    protected float val;
    protected float duration = 1.0f;
    protected bool finished;

    public void SetVal(float val)
    {
        this.val = val;
    }
    protected IEnumerator Command()
    {
        finished = false;
        float startTime = Time.time;
        float percentage = 0;
        while (Time.time < startTime + duration)
        {
            percentage = (Time.time - startTime) / duration;
            Busy(percentage);
            yield return null;
        }
        Busy(1f);
        finished = true;
    }
    protected IEnumerator Reverse_Command()
    {
        finished = false;
        float startTime = Time.time;
        float percentage = 0;
        while (Time.time < startTime + duration)
        {
            percentage = (Time.time - startTime) / duration;
            ReverseBusy(percentage);
            yield return null;
        }
        ReverseBusy(1f);
        finished = true;
    }
    public virtual void Run()
    {
        StartCoroutine(Command());
    }
    public virtual void ReverseRun()
    {
        StartCoroutine(Reverse_Command());
    }
    public bool Finished()
    {
        return finished;
    }
    protected virtual void Busy(float perc){}
    protected virtual void ReverseBusy(float perc){}
}
