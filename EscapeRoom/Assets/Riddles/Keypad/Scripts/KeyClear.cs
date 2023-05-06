using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeyClear : MonoBehaviour
{
    public TMP_Text text;
    void OnMouseDown()
    {
        text.text = "";
    }
}
