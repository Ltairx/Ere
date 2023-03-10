using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FourthBinaryNumber : Riddle
{
    public TMP_Text text;
    private void SetDigit(bool s)
    {
        if (s)
        {
            text.text = "1";
        }
        else
        {
            text.text = "0";
        }
    }
    public override Delegate GetFunction(int index)
    {
        return ((Action<bool>)SetDigit);
    }
}