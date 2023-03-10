using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreeNode : MonoBehaviour
{
    public GameObject backGroundObject;
    public Material matte, bright;
    public TextMeshProUGUI text;



    // Start is called before the first frame update
    void Start()
    {
        backGroundObject.GetComponent<MeshRenderer>().material = matte;
    }

    public void LightMaterial()
    {
        backGroundObject.GetComponent<MeshRenderer>().material = bright;
    }

    public void MatteMaterial()
    {
        backGroundObject.GetComponent<MeshRenderer>().material = matte;
    }


    public void SetText(string newText)
    {
        text.text = newText;
    }
}
