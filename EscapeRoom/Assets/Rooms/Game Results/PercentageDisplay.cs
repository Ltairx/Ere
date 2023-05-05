using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using TMPro;
public class PercentageDisplay : MonoBehaviour
{
    public GameManager.GameManager gameManager;
    public TMP_Text inf_text;
    public TMP_Text aut_text;
    public GameObject Inf_bar;
    public GameObject Aut_bar;

    // Start is called before the first frame update
    void Start()
    {
        float inf_perc = Percentage()[0]*100;
        float aut_percentage = Percentage()[1]*100;
        inf_text.text = inf_perc.ToString() + " informatykiem";
        aut_text.text = aut_percentage.ToString() + " automatykiem";
        inf_perc = 20f;
        Inf_bar.transform.localScale *= inf_perc;
        Aut_bar.transform.localScale *= aut_percentage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float[] Percentage()
    {
        float[] percentage = {0f, 0f};
        percentage[0] = gameManager.CalcDegreeKnowledge(Degree.COMPUTER_SCIENCE);
        percentage[1] = gameManager.CalcDegreeKnowledge(Degree.AUTOMATICS);
        return percentage;
    }
}
