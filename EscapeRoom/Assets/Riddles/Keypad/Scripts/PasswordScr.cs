using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class PasswordScr : MonoBehaviour
{
    public TMP_Text text;

    void Start()
    {
        int length = Random.Range(4, 10);
        string number = "";

        for (int i = 0; i < length; i++)
        {
            number += Random.Range(1, 10).ToString();
        }

        text.text = number;
    }
}
