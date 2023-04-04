using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ButtonController : Riddle
{
    public TMP_Text blok;
    public TMP_Text trans;
    private int n = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (n > 9)
        {
            n = 1;
        }
        if (n < 1)
        {
            n = 9;
        }
        blok.text = n.ToString();
        trans.text = n.ToString();
    }

    public override Delegate GetFunction(int index)
    {
        switch(index)
        {
            case 0:
                return (Action<float>)Decrement;
            case 1:
                return (Action<float>)Increment;
            default: 
                return null;
        }
    }

    private void Increment(float not_used)
    {
        n++;
    }

    private void Decrement(float not_used)
    {
        n--;
    }
}
