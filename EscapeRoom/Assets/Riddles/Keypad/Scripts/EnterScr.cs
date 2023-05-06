using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EnterScr : MonoBehaviour
{
    public TMP_Text Password;
    public TMP_Text InputText;
    public GameObject objectToRotate;

    private bool textsMatch = false;
    private bool objectRotated = false;

    private Quaternion start;
    private Quaternion stop;

    void OnMouseDown()
    {
        if (Password.text == InputText.text)
        {
            textsMatch = true;
        }
        else
        {
            InputText.text = "";
        }
    }

    private void Update()
    {
        if (textsMatch && !objectRotated)
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
