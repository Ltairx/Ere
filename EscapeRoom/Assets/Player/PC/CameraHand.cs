using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHand : Hand
{

    protected Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        camera = GetComponent<Camera>();
    }

    protected override void SendOutlineRay()
    {
        
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range, INTERACTABLE_LAYER)) //if hit interactable        
        {            
            if (Vector3.Distance(hit.transform.position, this.transform.position) < range)
            {                
                hit.transform.gameObject.GetComponent<InteractableInterface>().ShowOutline();
            }
        }
    }


    /// <summary>
    /// sends Ray from camera and position on screen and interact with hit object
    /// It uses INTERACTABLE_LAYER which is 10
    /// </summary>
    protected override InteractableInterface SendRay()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,range, INTERACTABLE_LAYER)) //if hit interactable        
        {            
            if (Vector3.Distance(hit.transform.position, this.transform.position) < range)
            {
                return hit.transform.gameObject.GetComponent<InteractableInterface>();
            }
        }
        return null;
    }



    public override Vector3 GetForwardVector()
    {
        Debug.DrawRay(camera.ScreenPointToRay(Input.mousePosition).origin, camera.ScreenPointToRay(Input.mousePosition).direction*5f,Color.blue);
        return camera.ScreenPointToRay(Input.mousePosition).direction;
    }
}
