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

    // Update is called once per frame
    void Update()
    {
        
    }
    public override Delegate GetFunction(int index)
    {
        switch (index)
        {
            case 9: //wpisanie komendy height
                return (Action<float>)Function;
            default:
                return null;
        }
    }

    void Function(float not_used)
    {
        StartCoroutine(Coroute());
    }

    IEnumerator Coroute()
    {
        float startTime = Time.time;
        float duration = 1f;
        //Quaternion startRot;
        //Quaternion endRot;
        //Quaternion startRot2;
        //Quaternion endRot2;
        //Quaternion startRot3;
        //Quaternion endRot3;
        //float val = 20;

        Vector3 startRot;   
        Vector3 endRot;
        Vector3 startRot2;
        Vector3 endRot2;
        float value = 0.00085f;

        //startRot = Arm1.transform.localRotation;
        //endRot = startRot * Quaternion.Euler(val, 0, 0);
        //startRot2 = Arm2.transform.localRotation;
        //endRot2 = startRot2 * Quaternion.Euler(2*val, 0, 0); //rotation of arm2
        //startRot3 = Wrist.transform.localRotation;
        //endRot3 = startRot3 * Quaternion.Euler(2*val, 0, 0); //rotation of wrist

        startRot = Finger1.transform.localPosition;
        endRot = startRot + new Vector3(value, 0, 0); //transposition of finger1
        startRot2 = Finger2.transform.localPosition;
        endRot2 = startRot2 + new Vector3(-value, 0, 0); //transposition of finger2

        while (Time.time < startTime + duration)
        {
            float procent = (Time.time - startTime) / duration;
            Finger1.transform.localPosition = Vector3.Lerp(startRot, endRot, procent);
            Finger2.transform.localPosition = Vector3.Lerp(startRot2, endRot2, procent);
            yield return null;
        }
    }
}
