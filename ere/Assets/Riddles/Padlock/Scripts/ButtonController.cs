using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{

    public TMP_Text liczba_tekst;
    int n = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(n>9)
        {
            n = 1;
        }
        liczba_tekst.text = n.ToString();
    }
}
