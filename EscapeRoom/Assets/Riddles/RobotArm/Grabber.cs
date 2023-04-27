using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public static bool grabbed = false;
    public static bool check_child = false;
    private GameObject child = null;
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
        if(child != null) check_child= true;
        else check_child = false;
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
