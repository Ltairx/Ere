using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : Holder<float> {}
public class Holder<T> : Interactable<T>
{
    public float DISTANCE = 2f;

    public override void Interact(Hand hand)
    {
        base.Interact(hand);
        transform.position = hand.transform.position + hand.GetForwardVector()*DISTANCE;        
    }
}

