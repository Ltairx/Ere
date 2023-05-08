using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RiddleDecimal : Riddle
{
    public TMP_Text outputText;
    public int randomIndex;
    public string binIndex;

    public int bit1;
    public int bit2;
    public int bit3;
    public int bit4;
    public int bit5;
    public int bit6;
    public int bit7;

    public Number1 FirstBinNumber;
    public SecBinaryNumber SecBinaryNumber;
    public ThirdBinaryNumber ThirdBinaryNumber;
    public FourthBinaryNumber FourthBinaryNumber;
    public FifthBinaryNumber FifthBinaryNumber;
    public SixthBinaryNumber SixthBinaryNumber;
    public SeventhBinaryNumber SeventhBinaryNumber;

    public GameObject LightBulb;
    public Material BulbYellow;
    public Material BulbColor;

    override protected void Start()
    {        
        randomIndex = Random.Range(64, 128);
        binIndex = System.Convert.ToString(randomIndex, 2);
        riddlePassword = binIndex;
        outputText.text = "" + randomIndex;

        bit1 = int.Parse(binIndex.Substring(0, 1));
        bit2 = int.Parse(binIndex.Substring(1, 1));
        bit3 = int.Parse(binIndex.Substring(2, 1));
        bit4 = int.Parse(binIndex.Substring(3, 1));
        bit5 = int.Parse(binIndex.Substring(4, 1));
        bit6 = int.Parse(binIndex.Substring(5, 1));
        bit7 = int.Parse(binIndex.Substring(6, 1));
        base.Start();
    }

    private void Update()
    {
        if (bit1 == int.Parse(FirstBinNumber.text.text) &&
           bit2 == int.Parse(SecBinaryNumber.text.text) &&
           bit3 == int.Parse(ThirdBinaryNumber.text.text) &&
           bit4 == int.Parse(FourthBinaryNumber.text.text) &&
           bit5 == int.Parse(FifthBinaryNumber.text.text) &&
           bit6 == int.Parse(SixthBinaryNumber.text.text) &&
           bit7 == int.Parse(SeventhBinaryNumber.text.text))
        {
            Renderer renderer = LightBulb.GetComponent<Renderer>();
            renderer.material = BulbYellow;
        }
        else
        {
            Renderer renderer = LightBulb.GetComponent<Renderer>();
            renderer.material = BulbColor;
        }
    }
}
