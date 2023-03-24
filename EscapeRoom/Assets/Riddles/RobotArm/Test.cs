using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Riddle
{

    public GameObject kostka;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coroute());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override Delegate GetFunction(int index)
    {
        switch (index)
        {
            case 0: //wpisanie komendy height
                return (Action<float>)function;
            default:
                return null;
        }
    }

    void function(float not_used)
    {
        
    }

    IEnumerator Coroute()
    {
        float startTime = Time.time;
        float duration = 0.9f;
        Vector3 startRot = kostka.transform.localRotation.eulerAngles;
        Vector3 endRot = new Vector3(0, 30, 0);
        Vector3 obrot;

        while (Time.time < startTime + duration)
        {
            float procent = (Time.time - startTime) / duration;
            obrot = Vector3.Lerp(startRot, endRot, procent);
            kostka.transform.localRotation = Quaternion.Euler(obrot);
            yield return null;
        }
    }
}
