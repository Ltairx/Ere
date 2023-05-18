using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public Material on, off;
    protected bool isOn = false;
    Renderer renderer;

    protected void Start()
    {
        renderer = GetComponent<Renderer>();
        LightOff();
    }

    public void Light()
    {
        renderer.material = on;
        isOn = true;
    }
    public void LightOff()
    {
        renderer.material = off;
        isOn = false;
    }

    public bool IsOn()
    {
        return isOn;
    }
}
