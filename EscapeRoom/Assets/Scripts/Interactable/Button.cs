using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button: Button<float> { }

public class Button<T> : Interactable<T>
{
    public AudioSource src1;
    public AudioClip sfx_1;
    protected override void OnStartInteract(Hand hand)
    {
        InteractTarget();
        if (src1!=null && sfx_1 != null)
        {
            src1.clip = sfx_1;
            src1.Play();
        }
    }
        
        
}
