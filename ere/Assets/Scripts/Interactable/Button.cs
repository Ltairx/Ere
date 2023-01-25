using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button: Button<float> { }

public class Button<T> : Interactable<T>
{    
    protected override void OnStartInteract(Hand hand)
    {
        InteractTarget();
    }
}
