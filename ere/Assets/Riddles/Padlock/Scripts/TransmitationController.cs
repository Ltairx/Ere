using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransmitationController : MonoBehaviour
{

    public TMP_Text s_3;
    public TMP_Text s_2;
    public TMP_Text s_1;
    public TMP_Text s_0;
    int a = 5, b = 1, c = 1, d = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        s_3.text = d.ToString();
        s_2.text = (c*d+b*d).ToString();
        s_1.text = (a+b*c*d).ToString();
        s_0.text = a.ToString();
    }
}
