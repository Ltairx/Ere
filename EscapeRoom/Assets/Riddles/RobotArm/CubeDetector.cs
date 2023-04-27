using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    private static bool in_position = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            in_position = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            in_position = false;
        }
    }

    public bool CheckPosition()
    {
        if (in_position) return true;
        else return false;
    }
}
