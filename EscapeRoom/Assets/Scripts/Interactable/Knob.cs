using System.Collections;
using UnityEngine;

public class Knob : Knob<(int, int)>
{
    
    protected override void ValueToSend(int value)
    {
        valToSend = (funcIndex, value);
    }
}

public class Knob<T> : Interactable<T>
{
    private int number;
    private bool coroutineAllowed;

    protected override void Start()
    {
        base.Start();
        coroutineAllowed = true;
        number = 5;
    }

    protected override void OnStartInteract(Hand hand)
    {
        if (coroutineAllowed)
        {
            StartCoroutine("RotateWheel");
        }
    }

    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(0f, 0f, -3f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;
        number -= 1;

        if (number < 0)
        {
            number = 9;
        }

        ValueToSend(number);
        InteractTarget();
    }

    protected virtual void ValueToSend(int value){}
}

