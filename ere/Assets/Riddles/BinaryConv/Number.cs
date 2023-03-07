using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextIncrementer : MonoBehaviour
{
    private float time = 0.0f;
    private float interval = 1.0f;
    private int number = 0;

    public TMP_Text text;

    void Update()
    {
        time += Time.deltaTime;

        if (time >= interval)
        {
            time = 0.0f;
            number++;

            if (number > 15)
            {
                number = 0;
            }

            text.text = "" + number;
        }
    }
}