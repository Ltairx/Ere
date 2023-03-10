using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Galka : MonoBehaviour
{
    public int[] array = new int[10];
    public int value;
    public TextMeshPro Text;

    public Binary_tree_game arr;
    // Start is called before the first frame update
    void Start()
    {
        Text = FindObjectOfType<TextMeshPro>();
        arr = GetComponent<Binary_tree_game>();
        array = arr.starting_array;
        value = array[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = value.ToString();
    }
}
