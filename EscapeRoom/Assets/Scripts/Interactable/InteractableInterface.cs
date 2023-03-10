using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// literaly interface foc interactables. Needed to rpeserve genericity in interactables
/// </summary>
public class InteractableInterface : MonoBehaviour
{
    virtual public void Interact(Hand hand){}
}
