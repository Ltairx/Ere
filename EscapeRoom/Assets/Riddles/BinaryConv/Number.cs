using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Number : MonoBehaviour
{
    private float time = 0.0f;
    private float interval = 1.0f;
    private int number = 0;

    public TMP_Text text;

    public TMP_Text bin1;
    public TMP_Text bin2;
    public TMP_Text bin4;
    public TMP_Text bin8;


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
            

            text.text = number.ToString();
            bin1.text = ((1 & number) != 0) ? "1" : "0";
            bin2.text = ((2 & number) != 0) ? "1" : "0";
            bin4.text = ((4 & number) != 0) ? "1" : "0";
            bin8.text = ((8 & number) != 0) ? "1" : "0";
       
        }
    }
}