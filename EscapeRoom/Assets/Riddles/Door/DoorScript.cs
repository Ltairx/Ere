using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DoorScript : MonoBehaviour
{    
    private bool objectRotated = false;
    [SerializeField] private bool clockwise = false;

    private Quaternion start;
    private Quaternion stop;


    IEnumerator rotate()
    {
        float StartTime = Time.time;
        float Duration = 1f;
        float Percentage = 0;
        while (Time.time < StartTime + Duration)
        {
            Percentage = (Time.time - StartTime) / Duration;
            opening(Percentage);
            yield return null;
        }
        opening(1f);
    }

    private void Start()
    {
        start = transform.localRotation;
        stop = start * Quaternion.Euler(0, clockwise? 90 : - 90, 0);

    }
    private void opening(float proc)
    {
        transform.localRotation = Quaternion.Lerp(start, stop, proc);
    }

    public void OpenTheDoor()
    {
        if (!objectRotated)
        {
            StartCoroutine(rotate());
            objectRotated = true;
        }
    }
}
