using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using System.Text;

public class KeypadScript : FunctionGettable
{
    public AudioSource src1;
    public AudioClip error_sound;

    public TMP_Text inputText;
    public List<string> password;

    [SerializeField] DoorScript door;

    private Material disMat;
    private Color basicColor; 


    int digits = 0;
    bool blocked = false;

    private void Start()
    {
        disMat = gameObject.GetComponent<Renderer>().materials[1];
        basicColor = disMat.color;
    }


    private void Update()
    {

        //if full number inputed        
        

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
        if (!blocked)
        {
            if (digits != password[0].Length)
            {
                StringBuilder sb = new StringBuilder(inputText.text);
                sb[digits++] = (char)((int)digit + '0');
                inputText.text = sb.ToString();
                CheckPassword();
            }
        }
    }

    void KeyClear(float not_used)
    {
        if (!blocked)
        {
            inputText.text = new string(inputText.text.ToCharArray().Select(c => '_').ToArray());
            digits = 0;
        }
    }


    void CheckPassword()
    {
        if (password.Count > 0 && digits == password[0].Length)
        {
            if (password.Contains(inputText.text))
            {
                door.OpenTheDoor();
                //glow green
                disMat.color = Color.green;
                blocked = true;
            }
            else
            {                
                //glow red, and then reset

                StartCoroutine(GlowRed());
                if (src1 != null && error_sound != null)
                {
                    src1.clip = error_sound;
                    src1.Play();
                }
            }
        }
    }


    IEnumerator GlowRed()
    {
        float startTime = Time.time;
        float duration = 1f;
        disMat.color = Color.red;
        while (Time.time< startTime + duration)
        {
            yield return null;
        }
        inputText.text = new string(inputText.text.ToCharArray().Select(c => '_').ToArray());
        disMat.color = basicColor;
        digits = 0;
    }


}

