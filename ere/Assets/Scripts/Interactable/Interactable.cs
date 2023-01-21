using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Interactable: Interactable<float> {}

/// <summary>
/// Base class for all interactable items in the game
/// 
/// Provides with variable such as:
/// interactedLastFrame - states if it's continuously interacted
/// 
/// WARNING, it's needed to create individual script which inherits on it, and has a specified TYPE (<T>)
/// It allows us to make interactables for specific types we want to send
/// </summary>
public class Interactable<T> : InteractableInterface { 

    //protected Action<T> action;

    protected bool interactedLastFrame; //in case of being continously interacted
    private int interactCounter;

    public Riddle riddle;
    public int funcIndex;
    protected Action<T> callFunc;    
    protected T valToSend;

    // Start is called before the first frame update
    protected virtual void Start()    
    {
        if (riddle != null)
        {
            callFunc = (Action<T>)riddle.GetFunction(funcIndex);
        }
    }

    /// <summary>
    /// used only for checking contunuous interaction (holding button for example)
    /// </summary>
    protected void Update()
    {
        if (interactCounter > 0) { interactCounter--; interactedLastFrame = true; };
        if (interactCounter == 0) interactedLastFrame = false;


    }


    /// <summary>
    /// public method to receive interaction request
    /// </summary>
    override public void Interact(Hand hand)
    {

        if (!interactedLastFrame)
        {
            //call some other function
            OnStartInteract(hand);            
        }
        interactCounter = 2; //used to indicate that it was interacted last frame
    }



    /// <summary>
    /// called only in the first frame of being interacted
    /// </summary>
    virtual protected void OnStartInteract(Hand hand)
    {

    }


    /// <summary>
    /// calls target object method while interacting
    /// call the method with specified at the beginning argument
    /// it's not supposed to be virtualized. IT PASSES ONLY ONE ARGUMENT, so you may you tuples or lists.
    /// </summary>
    protected void InteractTarget()
    {
        if (callFunc != null) { 
            callFunc(valToSend);
        }
    }
}
