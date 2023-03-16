using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// auxiliary class for Interactable. If gameobject which can be interacted, doesn't hold the the Interactable script
/// it calls the parent which has it. Solution for multiobject Interactables.
/// </summary>
public class InteractivePart : InteractableInterface
{
    public InteractableInterface parent;

    public override void Interact(Hand hand)
    {
        parent.Interact(hand);//pass it to the parent
    }
}
