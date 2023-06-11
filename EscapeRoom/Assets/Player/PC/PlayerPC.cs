using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// PC version of player which uses keyboard and mouse
/// </summary>
public class PlayerPC : Player
{
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    protected void MoveController(PlayerDirection direction)
    {
        Vector3 cameraDirection = camera.transform.forward;
        cameraDirection.y = 0; //to make it flat
        cameraDirection.Normalize(); //set length to 1


        switch (direction)
        {
            case PlayerDirection.FORWARD:
                //do not change the vector
                break;
            case PlayerDirection.BACKWARD:
                cameraDirection = Quaternion.Euler(0, 180, 0) * cameraDirection;
                //rotate 180 degrees
                break;
            case PlayerDirection.LEFT:
                cameraDirection = Quaternion.Euler(0, -90, 0) * cameraDirection;
                break;
            case PlayerDirection.RIGHT:
                cameraDirection = Quaternion.Euler(0, 90, 0) * cameraDirection;
                break;

        }

        controller.Move(cameraDirection * Time.deltaTime);
    }


    protected override void CheckKeys()
    {
        //keyboard Movement
        if (Input.GetKey("w"))
        {
            //Move(PlayerDirection.FORWARD);
            MoveController(PlayerDirection.FORWARD);
        }

        if (Input.GetKey("s"))
        {
            MoveController(PlayerDirection.BACKWARD);
        }

        if (Input.GetKey("a"))
        {
            MoveController(PlayerDirection.LEFT);
        }

        if (Input.GetKey("d"))
        {
            MoveController(PlayerDirection.RIGHT);
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
