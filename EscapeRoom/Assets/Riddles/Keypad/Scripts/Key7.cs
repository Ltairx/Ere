﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Key7 : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text text;
    void OnMouseDown()
    {
        text.text += "7";
    }
}