using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DoorScript : MonoBehaviour
{
    public TMP_Text Password;
    public TMP_Text InputText;
    public GameObject objectToRotate;

    private bool objectRotated = false;
    public bool IsKeypad;

    private Quaternion start;
    private Quaternion stop;

    // Update is called once per frame
    private void Update()
    {
        if (Password.text == InputText.text && !objectRotated && IsKeypad)
        {
            StartCoroutine(rotate());
            objectRotated = true;
        }
    }

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
        start = objectToRotate.transform.localRotation;
        stop = start * Quaternion.Euler(0, 0, -90);

    }
    private void opening(float proc)
    {
        objectToRotate.transform.localRotation = Quaternion.Lerp(start, stop, proc);
    }
}
