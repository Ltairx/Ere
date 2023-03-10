using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Bin4 : MonoBehaviour
{
    private float time = 0.0f;
    private float interval = 8.0f;
    private int number = 0;
    private string binaryString = "0";

    public TMP_Text text;

    void Update()
    {
        time += Time.deltaTime;

        if (time >= interval)
        {
            time = 0.0f;
            number++;


            if (number > 1)
            {
                number = 0;
            }

            text.text = "" + number;
        }
    }
}