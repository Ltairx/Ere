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
    public GameObject InfBar;
    public GameObject AutBar;
    public GameObject RawText;

    // Start is called before the first frame update
    void Start()
    {
        InfBar.SetActive(false);
        AutBar.SetActive(false);
        RawText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Display()
    {
        Vector3 scale_inf = InfBar.transform.localScale;
        Vector3 scale_aut = AutBar.transform.localScale;
        float inf_perc = gameManager.CalcDegreeKnowledge(Degree.COMPUTER_SCIENCE);
        float aut_perc = gameManager.CalcDegreeKnowledge(Degree.AUTOMATICS);

        inf_text.text = (inf_perc*100).ToString("0.0") + "%";
        aut_text.text = (aut_perc*100).ToString("0.0") + "%";

        scale_inf.x *= inf_perc;
        scale_aut.x *= aut_perc;
        InfBar.transform.localScale = scale_inf;
        AutBar.transform.localScale = scale_aut;
        InfBar.SetActive(true);
        AutBar.SetActive(true);
        RawText.SetActive(true);
    }
}
