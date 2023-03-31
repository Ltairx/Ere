using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using System.Net;

public class RobotCommunicator : Riddle
{
    // Start is called before the first frame update
    public GameObject Base;
    public GameObject Arm1;
    public GameObject Arm2;
    public GameObject Wrist;
    public GameObject Finger1;
    public GameObject Finger2;

    public TMP_Text[] commands_text = new TMP_Text[12];
    public TMP_Text height_text;
    public TMP_Text rotation_text;
    public TMP_Text fingers_text;

    private Quaternion startBase;
    private Quaternion startArm1;
    private Quaternion startArm2;
    private Quaternion startWrist;
    

    private int rotation_value = 0;
    private int height_value = 0;
    private int fingers_state = 0;

    private List<(operations, Instructions instruction)> queue = new List<(operations, Instructions instruction)>();
    private int iterator = 0;

    private bool stop = false;
    private bool done = true;

    private enum operations {height, rotation, fingers}
    void Start()
    {
        Instructions.Base = Base;
        Instructions.Arm1 = Arm1;
        Instructions.Arm2 = Arm2;
        Instructions.Wrist = Wrist;
        Instructions.Finger1 = Finger1;
        Instructions.Finger2 = Finger2;
        startBase =  Base.transform.localRotation;
        startArm1 = Arm1.transform.localRotation;
        startArm2 = Arm2.transform.localRotation;
        startWrist = Wrist.transform.localRotation;
    }


    // Update is called once per frame
    void Update()   
    {
        //height_text.text = queue.Count.ToString();
        //rotation_text.text = iterator.ToString(); do debugowania
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
            case 3: //start
                return (Action<float>)start_command;
            //case 4: //stop
            //    return (Action<float>)stop_command;
            case 5: //reset
                return (Action<float>)reset_command;
            case 6: //delline
                return (Action<float>)delline_command;
            case 7: //incr_hei
                return (Action<float>)increase_height;  
            case 8: //incr_rot
                return (Action<float>)increase_rot;
            case 9: //change_state
                return (Action<float>)change_fstate;
            case 10: //decr_hei
                return (Action<float>)decrease_height;
            case 11: //decr_rot
                return (Action<float>)decrease_rot;
            default:
                return null;
        }
    }
    void height_command(float not_used)
    {
        if (iterator < 12)
        {
            Height height = commands_text[iterator].gameObject.AddComponent<Height>();
            height.setval(height_value);
            queue.Add((operations.height, height));
            commands_text[iterator].text = "change height_value " + height_value.ToString();
        }
        else iterator = 11;
        iterator++;
    }
    void rotation_command(float not_used)
    {
        if (iterator < 12)
        {
            Rotation rotation = commands_text[iterator].gameObject.AddComponent<Rotation>();
            rotation.setval(rotation_value);
            queue.Add((operations.rotation, rotation));
            commands_text[iterator].text = "change rotation_value " + rotation_value.ToString();
        }
        else iterator = 11;
        iterator++;
}
    void fingers_command(float not_used)
    {
        if (iterator < 12)
        {
            Fingers fingers = commands_text[iterator].gameObject.AddComponent<Fingers>();
            fingers.setval(fingers_state);
            queue.Add((operations.fingers, fingers));
            commands_text[iterator].text = "change finger_state " + fingers_state.ToString();
        }
        else iterator = 11;
        iterator++;
    }
    void  start_command(float not_used) 
    {
        if (done)
        {
            done = false;
            StartCoroutine(Queue_exe());
        }
    }
    //void stop_command(float not_used)
    //{
    //    stop = true;
    //}
    void reset_command(float not_used)
    {
        //stop_command(not_used);
        if (iterator > 11) iterator = 11;
        for (int i = 0; i <= iterator; i++)
        {
            Destroy(commands_text[iterator].gameObject.GetComponent<Instructions>());
            commands_text[i].text = "";
        }
        queue.Clear();
        iterator = 0;
    }
    void delline_command(float not_used)
    {
        //stop_command(not_used);
        iterator--;
        if (iterator < 0) iterator = 0;
        Destroy(commands_text[iterator].gameObject.GetComponent<Instructions>());
        commands_text[iterator].text = "";
        if (queue.Count > 0)
        {
            queue.RemoveAt(queue.Count - 1);
        }
    }
    void increase_height(float not_used) 
    {
        height_value += 10;
        if(height_value > 40)
        {
            height_value = -40;
        }
        height_text.text = height_value.ToString() + "0mm";
    }
    void increase_rot(float not_used)
    {
        rotation_value += 10;
        if (rotation_value > 180)
        {
            rotation_value = -180;
        }
        rotation_text.text = rotation_value.ToString() + "°";
    }
    void change_fstate(float not_used)
    {
        if (fingers_state == 0)
        {
            fingers_state++;
            fingers_text.text = "ODŁÓŻ";
        }
        else
        {
            fingers_state--;
            fingers_text.text = "ZŁAP";
        }
    }
    void decrease_height(float not_used)
    {
        height_value -= 10;
        if (height_value < -40)
        {
            height_value = 40;
        }
        height_text.text = height_value.ToString() + "0mm";
    }
    void decrease_rot(float not_used)
    {
        rotation_value -= 10;
        if (rotation_value < -180)
        {
            rotation_value = 180;
        }
        rotation_text.text = rotation_value.ToString() + "°";
    }
    IEnumerator Queue_exe()
    {
        stop = false;
        foreach ((operations o, Instructions instruction) com in queue)
        {
            //if(stop) break;
            com.instruction.Run();
            while (!com.instruction.Finished())
            {
                yield return null;
            }
        }
        done = true;
    }    
}
