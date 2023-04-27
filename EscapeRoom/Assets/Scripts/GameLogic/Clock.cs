using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI text;

    const float MAXTIME = 60 * 60; //full hour

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timePassed = Time.time;
        float timeLeft = MAXTIME - timePassed;
        UpdateText(timeLeft);
    }


    void UpdateText(float time)
    {
        int minutes,seconds,miliseconds;

        minutes = (int)(time/60);
        seconds = (int)(time)%60;
        miliseconds = (int)(time*100) % 100;


        text.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");

    }
}
