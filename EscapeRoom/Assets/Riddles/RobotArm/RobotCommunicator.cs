using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RobotCommunicator : Riddle
{
    // Start is called before the first frame update
    public GameObject Base;
    public GameObject Arm1;
    public GameObject Arm2;
    public GameObject Finger1;
    public GameObject Finger2;

    public TMP_Text height;
    public TMP_Text rotation;
    public TMP_Text fingers;

    private int rotation_value = 30;
    private int height_value = 10;
    private int fingers_state = 0;

    private int[,] queue;
    private int iterator = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()   
    {
        if(iterator>13)
        {
            iterator = 13;
        }
        if(rotation_value>360)
        {
            rotation_value = 0;
        }
        height.text = iterator.ToString();
    }
    public override Delegate GetFunction(int index)
    {
        switch (index)
        {
            case 0: //wpisanie komendy height
                return (Action<float>)height_command; 
            case 1: //wpisanie komendy rotation
                return (Action<float>)rotation_command;
            case 2: //wpisanie komendy finger
                return (Action<float>)fingers_command;
            //case 3: //start
            //    return (Action<float>)Decrement;
            //case 4: //stop
            //    return (Action<float>)Decrement;
            //case 5: //reset
            //    return (Action<float>)Decrement;
            //case 6: //del_line
            //    return (Action<float>)Decrement;
            default:
                return null;
        }
    }
    void height_command(float not_used)
    {
        queue[iterator, 0] = 0;
        queue[iterator, 1] = height_value;
        iterator++;
    }
    void rotation_command(float not_used)
    {
        queue[iterator, 0] = 1;
        queue[iterator, 1] = rotation_value;
        iterator++;
    }
    void fingers_command(float not_used)
    {
        queue[iterator, 0] = 2;
        queue[iterator, 1] = fingers_state;
        iterator++;
    }
    //yield return null
    //while(time.time<time.time+
}
