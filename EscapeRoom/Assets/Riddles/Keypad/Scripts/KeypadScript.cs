using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using System.Text;

public class KeypadScript : FunctionGettable
{
    public TMP_Text inputText;
    public List<string> password;

    [SerializeField] DoorScript door;

    int digits = 0;

    private void Update()
    {

        //if full number inputed
        if (password.Count>0 && digits == password[0].Length)
        {


            if (password.Contains(inputText.text))
            {
                door.OpenTheDoor();
            }
            else
            {
                inputText.text = new string(inputText.text.ToCharArray().Select(c => '_').ToArray());
                digits = 0;
            }
        }
        

    }

    public void AddPassword(string newPassword)
    {
        password.Add(newPassword);

        //set _ for each digit
        inputText.text = new string(newPassword.ToCharArray().Select(c => '_').ToArray());
    }


    public override Delegate GetFunction(int index)
    {
        switch (index)
        {
            case 0: //dodanie cyfry
                return (Action<float>)KeyZero;
            case 1: //czyszczenie ekranu
                return (Action<float>)KeyClear;
            default:
                return null;
        }
    }



    void KeyZero(float digit)
    {
        StringBuilder sb = new StringBuilder( inputText.text);
        sb[digits++] = (char)((int)digit+'0');
        inputText.text = sb.ToString();
    }

    void KeyClear(float not_used)
    {
        inputText.text = new string(inputText.text.ToCharArray().Select(c => '_').ToArray());
    }
}

