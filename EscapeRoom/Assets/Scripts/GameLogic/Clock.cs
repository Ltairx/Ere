using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameManager;

public class Clock : MonoBehaviour
{ 

    [SerializeField]
    TextMeshProUGUI text;

    const float MAXTIME = 60 * 60; //full hour
    public static bool stoppedCounting = false;
    static bool gameManagerCalled = false;
    GameManager.GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager.GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float timePassed = Time.time;
        float timeLeft = MAXTIME - timePassed;

        if (!stoppedCounting)
        {
            if (timeLeft < 0)
            {
                UpdateText(0);
                CallGameManager();
            }
            else
            {
                UpdateText(timeLeft);
            }
        }

    }


    void UpdateText(float time)
    {
        int minutes,seconds,miliseconds;

        minutes = (int)(time/60);
        seconds = (int)(time)%60;
        miliseconds = (int)(time*100) % 100;


        text.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
    }


    void CallGameManager()
    {
        if (!gameManagerCalled)
        {
            gameManager.EndGame();
        }

        gameManagerCalled = true;
    }

    
}
