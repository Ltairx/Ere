using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerDirection{
    FORWARD,
    BACKWARD,
    LEFT,
    RIGHT
}


/// <summary>
/// Base class for Player
/// </summary>
public class Player : MonoBehaviour
{

    public Camera camera;
    public Hand leftHand, rightHand;
    public float speed=1;
    public float angularSpeed=50;

    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {        
        CheckKeys();
    }


    /// <summary>
    /// move player accordingly to where he is looking
    /// </summary>
    protected void Move(PlayerDirection direction)
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

        Move(cameraDirection);
    }


    /// <summary>
    /// /// move player accordingly to controller and camera
    /// </summary>
    /// <param name="direction"></param>
    protected void Move(Vector3 direction)
    {
        transform.position += direction*speed*Time.deltaTime;
    }

    /// <summary>
    /// rotate accordingly to direction
    /// </summary>
    /// <param name="clockwise"></param>
    protected void Rotate(bool clockwise)
    {
        Vector3 euler = transform.rotation.eulerAngles;
        float angle = clockwise ? angularSpeed : -angularSpeed;
        angle*=Time.deltaTime;
        euler.y += angle;
        transform.transform.rotation = Quaternion.Euler(euler);
    }


    /// <summary>
    /// send Interact ray from one hand
    /// </summary>
    /// <param name="leftHandRay"></param>
    protected void Interact(bool leftHandRay)
    {        

        if (leftHandRay)
        {
            leftHand.Interact();
        }
        else
        {
            rightHand.Interact();
        }
    }

    protected void StopInteracting(bool leftHandRay)
    {

        if (leftHandRay)
        {
            leftHand.StopInteracting();
        }
        else
        {
            rightHand.StopInteracting();
        }
    }


    /// <summary>
    /// virtual function to checkKeys of controllers or keyboard/mouse
    /// </summary>
    protected virtual void CheckKeys() { }

}
