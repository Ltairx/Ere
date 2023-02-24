using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public Material on, off;

    Renderer renderer;

    protected void Start()
    {
        renderer = GetComponent<Renderer>();
        LightOff();
    }

    public void Light()
    {
        renderer.material = on;
    }
    public void LightOff()
    {
        renderer.material = off;
    }
}
