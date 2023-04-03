using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DisplayScript : MonoBehaviour
{
    public TMP_Text text;

    void Update()
    {
        if (text.text.Length > 9)
        {
            text.text = text.text.Substring(0, Mathf.Min(text.text.Length, 9));
        }
    }
}
