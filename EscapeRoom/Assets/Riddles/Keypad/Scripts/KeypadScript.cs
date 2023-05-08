using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeypadScript : FunctionGettable
{
    public TMP_Text inputText;
    public List<string> password;

    [SerializeField] DoorScript door;

    private void Update()
    {
        if (password.Contains(inputText.text))
        {
            door.OpenTheDoor();
        }
    }

    public void AddPassword(string newPassword)
    {
        password.Add(newPassword);
    }


    public override Delegate GetFunction(int index)
    {
        switch (index)
        {
            case 0: //wpisanie komendy height
                return (Action<float>)KeyZero;
            case 1: //wpisanie komendy rotation
                return (Action<float>)KeyOne;
            case 2: //wpisanie komendy finger
                return (Action<float>)KeyTwo;
            case 3: //start
                return (Action<float>)KeyThree;
            case 4: //stop
                return (Action<float>)KeyFour;
            case 5: //reset
                return (Action<float>)KeyFive;
            case 6: //delline
                return (Action<float>)KeySix;
            case 7: //incr_hei
                return (Action<float>)KeySeven;
            case 8: //incr_rot
                return (Action<float>)KeyEight;
            case 9: //change_state
                return (Action<float>)KeyNine;
            case 10: //change_state
                return (Action<float>)KeyClear;
            default:
                return null;
        }
    }


    #region keys

    void KeyZero(float not_used)
    {
        if (inputText.text.Length < 9)
        {
            inputText.text += "0";
        }
    }

    void KeyOne(float not_used)
    {
        if (inputText.text.Length < 9)
        {
            inputText.text += "1";
        }
    }

    void KeyTwo(float not_used)
    {
        if (inputText.text.Length < 9)
        {
            inputText.text += "2";
        }
    }

    void KeyThree(float not_used)
    {
        if (inputText.text.Length < 9)
        {
            inputText.text += "3";
        }
    }

    void KeyFour(float not_used)
    {
        if (inputText.text.Length < 9)
        {
            inputText.text += "4";
        }
    }

    void KeyFive(float not_used)
    {
        if (inputText.text.Length < 9)
        {
            inputText.text += "5";
        }
    }

    void KeySix(float not_used)
    {
        if (inputText.text.Length < 9)
        {
            inputText.text += "6";
        }
    }

    void KeySeven(float not_used)
    {
        if (inputText.text.Length < 9)
        {
            inputText.text += "7";
        }
    }

    void KeyEight(float not_used)
    {
        if (inputText.text.Length < 9)
        {
            inputText.text += "8";
        }
    }

    void KeyNine(float not_used)
    {
        if (inputText.text.Length < 9)
        {
            inputText.text += "9";
        }
    }

    void KeyClear(float not_used)
    {
        inputText.text = "";
    }
    #endregion
}

