using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// PC version of player which uses keyboard and mouse
/// </summary>
public class PlayerPC : Player
{

    protected override void CheckKeys()
    {
        //keyboard Movement
        if (Input.GetKey("w"))
        {
            Move(PlayerDirection.FORWARD);
        }

        if (Input.GetKey("s"))
        {
            Move(PlayerDirection.BACKWARD);
        }

        if (Input.GetKey("a"))
        {
            Move(PlayerDirection.LEFT);
        }

        if (Input.GetKey("d"))
        {
            Move(PlayerDirection.RIGHT);
        }

        //keyboard Rotation
        //sideways
        if (Input.GetKey("e"))
        {
            Rotate(true);
        }

        if (Input.GetKey("q"))
        {
            Rotate(false);
        }


        //verticaly
        if (Input.GetKey("r"))
        {
            RotateHead(true);
        }

        if (Input.GetKey("f"))
        {
            RotateHead(false);
        }

        //mouse
        if (Input.GetMouseButton(0))
        {
            this.Interact(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            this.StopInteracting(true);
        }
    }


    private void RotateHead(bool upwards)
    {
        Vector3 euler = camera.transform.rotation.eulerAngles;
        float angle = upwards ? -angularSpeed : angularSpeed;
        angle *= Time.deltaTime;
        euler.x += angle;
        camera.transform.transform.rotation = Quaternion.Euler(euler);
    }
}
