using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// vr playyer movement is already implemented in LZWPLib, so
/// this class need only to call Interact Function
/// </summary>
public class PlayerVR : Player
{
    protected override void CheckKeys()
    {
        if (Lzwp.initialized)
        {
            //If left? right? fire button is pressed
            if (Lzwp.input.flysticks[0].buttons[0].isActive)
            {
                leftHand.Interact(); //might need to swap hands XD
            }
            else
            {
                leftHand.StopInteracting();
            }


            if (Lzwp.input.flysticks[1].buttons[0].isActive)
            {
                rightHand.Interact();
            }
            else
            {
                rightHand.StopInteracting();
            }
        }
    }

    #region logic

    #endregion

}
