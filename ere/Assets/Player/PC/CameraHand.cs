using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHand : Hand
{

    protected Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }


    /// <summary>
    /// sends Ray from camera and position on screen and interact with hit object
    /// It uses INTERACTABLE_LAYER which is 10
    /// </summary>
    protected override InteractableInterface SendRay()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, INTERACTABLE_LAYER)) //if hit interactable        
        {
            Debug.DrawRay(ray.origin ,ray.direction*3, Color.red,1);
            if (Vector3.Distance(hit.transform.position, this.transform.position) < range)
            {
                return hit.transform.gameObject.GetComponent<InteractableInterface>();
            }
        }
        return null;
    }

    public override Vector3 GetForwardVector()
    {
        return camera.ScreenPointToRay(Input.mousePosition).direction;
    }
}
