using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum DIRECTION {
    NONE,
    NORTH,
    WEST,
    EAST,
    SOUTH,
    ACTUAL_POS,
    CANT_STEP
}


public class Tile : MonoBehaviour
{
    public GameObject plane;
    public GameObject canvas;
    public TextMeshPro text;

    //materials
    public Material white,red,yellow,green,blue,pink,black;

    protected int val = 0;
    protected bool lighted=false;

    public void SetVal(int val)
    {
        this.val=val;
        text.text = val.ToString();
    }

    public int GetVal()
    {
        return val;
    }

    public bool GetLighted()
    {
        return lighted;
    }

    public void SetMaterial(DIRECTION color)
    {
        switch (color)
        {
            case DIRECTION.NONE:
                lighted = false;
                plane.GetComponent<MeshRenderer>().material = white;
                break;
            case DIRECTION.NORTH:
                lighted = true;
                plane.GetComponent<MeshRenderer>().material = blue;
                break;
            case DIRECTION.WEST:
                lighted = true;
                plane.GetComponent<MeshRenderer>().material = green;
                break;
            case DIRECTION.EAST:
                lighted = true;
                plane.GetComponent<MeshRenderer>().material = yellow;
                break;
            case DIRECTION.SOUTH:
                lighted = true;
                plane.GetComponent<MeshRenderer>().material = red;
                break;      
            case DIRECTION.ACTUAL_POS:                
                plane.GetComponent<MeshRenderer>().material = pink;
                break; 
            case DIRECTION.CANT_STEP:
                //called only in the first frame!
                canvas.SetActive(false);
                plane.GetComponent<MeshRenderer>().material = black;
                break;            
        }
    }

}
