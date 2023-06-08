using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Node_script : Riddle
{
   // public AudioSource src1;
   // public AudioClip sfx_1;
    public GameObject knob;
    public int knob_number = 0;
    public int value = 0;
    public TextMeshPro Text;
    // Start is called before the first frame update
    void Start()
    {
        Text.text = value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = value.ToString();
    }

    public void Set_knob_number(int number)
    {
        knob_number = number;
    }

    public void Set_knob_value(int number)
    {
        value = number;
    }

    void Turn_galka(float a)
    {
     //   src1.clip = sfx_1;
     //   src1.Play();
        knob.transform.Rotate(new Vector3(0, 90, 0));
        //Debug.Log("Krece sie");
        FindObjectOfType<Binary_tree_game>().Update_Value(knob_number);
        FindObjectOfType<Binary_tree_game>().In_progress();
    }
    public override System.Delegate GetFunction(int index)
    {
        return ((Action<float>)Turn_galka);
        //return ((Action<float>) Move);        
    }
}

//zwróc wartoœæ
// ustaw wartoœæ na podstawie tabeli
// Pobierz ca³¹ tablice 
// zmieñ po przekrêceniu 
// Przekrêæ ga³k¹ 