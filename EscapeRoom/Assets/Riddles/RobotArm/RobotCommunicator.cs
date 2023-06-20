using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class RobotCommunicator : Riddle
{
    public AudioSource src1;
    public AudioClip fingers_sound;
    public AudioClip arm_sound;
    public AudioClip base_sound;
    //private bool stop = false;
    private bool done = true;
    private bool riddle_done = false;
    private bool[] riddle_percentage = {false, false, false, false, false, false};
    private bool[] types_of_commands = {false, false, false};

    private int rotation_value = 0;
    private int height_value = 0;
    private int fingers_state = 0;
    private int iterator = 0;

    private float percentage_total = 0f;

    public GameObject Base;
    public GameObject Arm1;
    public GameObject Arm2;
    public GameObject Wrist;
    public GameObject Finger1;
    public GameObject Finger2;
    public GameObject Cube;

    public TMP_Text[] commands_text = new TMP_Text[12];
    public TMP_Text height_text;
    public TMP_Text rotation_text;
    public TMP_Text fingers_text;

    private Quaternion startBase;
    private Quaternion startArm1;
    private Quaternion startArm2;
    private Quaternion startWrist;
    private Vector3 startFinger1;
    private Vector3 startFinger2;
    private Vector3 startCube;

    private List<(Operations, Instructions instruction)> queue = new List<(Operations, Instructions instruction)>();

    private static CubeDetector cubeDetector;

    private enum Operations {height, rotation, fingers};
    private enum Percentage {solved, solved_under, start, all_commands, grabbed, moved};

    protected override void Start()
    {
        base.Start();
        Instructions.src1 = src1;
        Instructions.fingers_sound = fingers_sound;
        Instructions.arm_sound = arm_sound;
        Instructions.base_sound = base_sound;
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
        startFinger1 = Finger1.transform.localPosition;
        startFinger2 = Finger2.transform.localPosition;
        startCube = Cube.transform.localPosition;
        cubeDetector = Base.AddComponent<CubeDetector>();
    }

    // Update is called once per frame
    void Update()   
    {
    }
    public override Delegate GetFunction(int index)
    {
        switch (index)
        {
            case 0: //wpisanie komendy height
                return (Action<float>)HeightCommand;
            case 1: //wpisanie komendy rotation
                return (Action<float>)RotationCommand;
            case 2: //wpisanie komendy finger
                return (Action<float>)FingersCommand;
            case 3: //start
                return (Action<float>)StartCommand;
            //case 4: //stop
                    //return (Action<float>)stop_command;
            case 5: //reset
                return (Action<float>)ResetCommand;
            case 6: //delline
                return (Action<float>)DelLineCommand;
            case 7: //incr_hei
                return (Action<float>)IncreaseHeight;  
            case 8: //incr_rot
                return (Action<float>)IncreaseRot;
            case 9: //change_state
                return (Action<float>)ChangeFState;
            case 10: //decr_hei
                return (Action<float>)DecreaseHeight;
            case 11: //decr_rot
                return (Action<float>)DecreaseRot;
            default:
                return null;
        }
    }
    private void HeightCommand(float not_used)
    {
        if (done)
        { 
            if (iterator < 12)
            {
                Height height = commands_text[iterator].gameObject.AddComponent<Height>();
                height.SetVal(height_value);
                queue.Add((Operations.height, height));
                commands_text[iterator].text = "change height_value " + (-height_value).ToString();
            }
            else iterator = 11;
            iterator++;
        }
    }
    private void RotationCommand(float not_used)
    {
        if (done)
        {
            if (iterator < 12)
            {
                Rotation rotation = commands_text[iterator].gameObject.AddComponent<Rotation>();
                rotation.SetVal(rotation_value);
                queue.Add((Operations.rotation, rotation));
                commands_text[iterator].text = "change rotation_value " + rotation_value.ToString();
            }
            else iterator = 11;
            iterator++;
        }
    }
    private void FingersCommand(float not_used)
    {
        if (done)
        {
            if (iterator < 12)
            {
                Fingers fingers = commands_text[iterator].gameObject.AddComponent<Fingers>();
                fingers.SetVal(fingers_state);
                queue.Add((Operations.fingers, fingers));
                commands_text[iterator].text = "change finger_state " + fingers_state.ToString();
            }
            else iterator = 11;
            iterator++;
        }
    }
    private void StartCommand(float not_used) 
    {
        if(queue.Count > 0 && !riddle_percentage[(int)Percentage.start])
        {
            riddle_percentage[(int)Percentage.start] = true;// dodać jeszcze wykrywanie 3 komend
            percentage_total += 0.1f;
        }
        if (done)
        {
            done = false;
            StartCoroutine(Queue_Exe());
        }
    }
    //void stop_command(float not_used)
    //{
    //    stop = true;
    //}
    private void ResetCommand(float not_used)
    {
        if (done)
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
            ResetPos();
        }
    }
    private void DelLineCommand(float not_used)
    {
        if (done)
        {
            //stop_command(not_used);
            iterator--;
            if (iterator < 0) iterator = 0;
            if (queue.Count > 0)
            {
                queue.RemoveAt(queue.Count - 1);
            }
            Destroy(commands_text[iterator].gameObject.GetComponent<Instructions>());
            commands_text[iterator].text = "";
        }
    }
    private void IncreaseHeight(float not_used)
    {
        height_value -= 10;
        if (height_value < -40)
        {
            height_value = 40;
        }
        height_text.text = (-height_value).ToString() + "cm";
    }
    private void DecreaseHeight(float not_used) 
    {
        height_value += 10;
        if(height_value > 40)
        {
            height_value = -40;
        }   
        height_text.text = (-height_value).ToString() + "cm";
    }
    private void IncreaseRot(float not_used)
    {
        rotation_value += 10;
        if (rotation_value > 180)
        {
            rotation_value = -180;
        }
        rotation_text.text = rotation_value.ToString() + "°";
    }
    private void DecreaseRot(float not_used)
    {
        rotation_value -= 10;
        if (rotation_value < -180)
        {
            rotation_value = 180;
        }
        rotation_text.text = rotation_value.ToString() + "°";
    }
    private void ChangeFState(float not_used)
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
    private IEnumerator Queue_Exe()
    {
        //stop = false;
        foreach ((Operations o, Instructions instruction) com in queue)
        {
            //if(stop) break;
            if (com.Item1 == Operations.height)
            {
                types_of_commands[(int)Operations.height] = true;
            }
            if (com.Item1 == Operations.rotation)
            {
                types_of_commands[(int)Operations.rotation] = true;
            }
            if (com.Item1 == Operations.fingers)
            {
                types_of_commands[(int)Operations.fingers] = true;
            }
            if (Cube.transform.localPosition != startCube && !riddle_percentage[(int)Percentage.moved])
            {
                riddle_percentage[(int)Percentage.moved] = true;
                percentage_total += 0.2f;
            }
            com.instruction.Run();
            while (!com.instruction.Finished())
            {
                if (Grabber.check_child) riddle_percentage[(int)Percentage.grabbed] = true;
                yield return null;
            }
        }
        if (types_of_commands[(int)Operations.height] && types_of_commands[(int)Operations.rotation] && types_of_commands[(int)Operations.fingers] && !riddle_percentage[(int)Percentage.all_commands])
        {
            riddle_percentage[(int)Percentage.all_commands] = true;
            percentage_total += 0.1f;
        }
        else
        {
            types_of_commands[(int)Operations.height] = false;
            types_of_commands[(int)Operations.rotation] = false;
            types_of_commands[(int)Operations.fingers] = false;
        }
        // ^to jest do wykrywania czy program wystartował ze wszystkimi 3 operacjami
        riddle_done = cubeDetector.CheckPosition();
        if (!riddle_done)
        {
            StartCoroutine(Reverse_Queue());
        }
        else
        {
            riddle_percentage[(int)Percentage.solved] = true;
            percentage_total += 0.5f;
            if (queue.Count < 8)
            {
                riddle_percentage[(int)Percentage.solved_under] = true;
                percentage_total += 0.1f;
            }
            OnSolve();
        }
        //done = true;
    }    
    private IEnumerator Reverse_Queue()
    {
        foreach ((Operations o, Instructions instruction) com in queue.Reverse<(Operations, Instructions)>())
        {
            //if(stop) break;
            com.instruction.ReverseRun();
            while (!com.instruction.Finished())
            {
                yield return null;
            }
        }
        done = true;
    }
    private void ResetPos()
    {
        Base.transform.localRotation = startBase;
        Arm1.transform.localRotation = startArm1;
        Arm2.transform.localRotation = startArm2;
        Wrist.transform.localRotation = startWrist;
        Finger1.transform.localPosition = startFinger1;
        Finger2.transform.localPosition = startFinger2;
    }
    public override float GetSolvePercentage()
    {
        return percentage_total;
    }
}
