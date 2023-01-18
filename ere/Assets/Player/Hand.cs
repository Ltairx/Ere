using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    protected int INTERACTABLE_LAYER = 10;

    InteractableInterface hitGameobject;
    bool once=true;

    public float range = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected virtual InteractableInterface SendRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) //if hit interactable        
        {
            if (Vector3.Distance(hit.transform.position, this.transform.position) < range)
            {
                return hit.transform.gameObject.GetComponent<InteractableInterface>();
            }
        }

        return null;
    }

    /// <summary>
    /// sends Ray from forward vector and interact with hit object
    /// It uses INTERACTABLE_LAYER which is 10
    /// </summary>
    public void Interact()
    {
        if (once)
        {
            hitGameobject = SendRay();
            once = false;
        }

        if(hitGameobject != null)
        {
            hitGameobject.Interact(this);
        }
    }


    /// <summary>
    /// returns forward vector, but it's different for camera!
    /// </summary>
    /// <returns></returns>
    public virtual Vector3 GetForwardVector()
    {
        return transform.forward;
    }

    public void StopInteracting()
    {
        hitGameobject = null;
        once = true;
    }

}
