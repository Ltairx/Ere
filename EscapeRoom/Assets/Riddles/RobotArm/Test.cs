using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Riddle
{

    public GameObject Base;
    public GameObject Arm1;
    public GameObject Arm2;
    public GameObject Wrist;
    public GameObject Finger1;
    public GameObject Finger2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override Delegate GetFunction(int index)
    {
        switch (index)
        {
            case 9: //wpisanie komendy height
                return (Action<float>)function;
            default:
                return null;
        }
    }

    void function(float not_used)
    {
        StartCoroutine(Coroute());
    }

    IEnumerator Coroute()
    {
        float startTime = Time.time;
        float duration = 0.4f;
        Quaternion startRot;
        Quaternion endRot;
        Quaternion startRot2;
        Quaternion endRot2;
        Quaternion startRot3;
        Quaternion endRot3;
        float val = 20;

        startRot = Arm1.transform.localRotation;
        endRot = startRot * Quaternion.Euler(val, 0, 0);
        startRot2 = Arm2.transform.localRotation;
        endRot2 = startRot2 * Quaternion.Euler(2*val, 0, 0); //rotation of arm2
        startRot3 = Wrist.transform.localRotation;
        endRot3 = startRot3 * Quaternion.Euler(2*val, 0, 0); //rotation of wrist

        while (Time.time < startTime + duration)
        {
            float procent = (Time.time - startTime) / duration;
            Arm1.transform.localRotation = Quaternion.Lerp(startRot, endRot, procent);
            Arm2.transform.localRotation = Quaternion.Lerp(startRot2, endRot2, procent);
            Wrist.transform.localRotation = Quaternion.Lerp(startRot3, endRot3, procent);
            yield return null;
        }
    }
}
