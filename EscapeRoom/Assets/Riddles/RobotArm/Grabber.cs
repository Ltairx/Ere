using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public static bool grabbed = false;
    GameObject child = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(!grabbed)
        {
            if(child != null) 
            {
                child.transform.parent = null;
                child = null;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (child == null)
        {
            if (other.gameObject.CompareTag("Cube"))
            {
                other.gameObject.transform.SetParent(gameObject.transform);
                child = other.gameObject;
            }
        }
    }
}
