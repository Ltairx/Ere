using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NumberDisplay : MonoBehaviour
{

    public SignalSource source;

    public GameObject[] numbers;    


    private void Update()
    {
        CheckInput();
    }

    protected  void CheckInput()
    {
        if(source.GetOutput() == true)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }


    void Show()
    {
        foreach(GameObject go in numbers)
        {
            go.SetActive(true);
        }
    }

    void Hide()
    {
        foreach (GameObject go in numbers)
        {
            go.SetActive(false);
        }
    }
}
