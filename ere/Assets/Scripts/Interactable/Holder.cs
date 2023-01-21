using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : Holder<float> {}
public class Holder<T> : Interactable<T>
{
    public float DISTANCE = 2f;

    public float lerpness = 0.05f; //seems to be ideal

    public override void Interact(Hand hand)
    {
        base.Interact(hand);
        Move(hand);
    }

    protected virtual void Move(Hand hand)
    {
        Vector3 newPos = Vector3.Lerp(transform.position, hand.transform.position + hand.GetForwardVector() * DISTANCE, lerpness + Time.deltaTime);
        //transform.position += (newPos - transform.position) * Time.deltaTime;
        transform.position = newPos;
    }

}

