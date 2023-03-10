using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Binary_tree_game : Riddle
{

    public int[] starting_array = new int[10];
    public int[] ending_array = new int[10];
    public int[] node_value_array = new int[10];
    public GameObject[] Nodes = new GameObject[10];
    private 
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            float randomNumber = Random.Range(1, 99);
            starting_array[i] = (int) randomNumber;
            ending_array[i] = i;
            node_value_array[i] = i;
            Nodes[i].GetComponent<Node_script>().Set_knob_number(i);
            Nodes[i].GetComponent<Node_script>().Set_knob_value(starting_array[i]);
        }
        bool not_git = true;
        int test = 0;
        while (not_git)
        {
            for(int i = 0; i < 9; i++)
            {
                if(starting_array[ending_array[i]]> starting_array[ending_array[i + 1]])
                {
                    test = ending_array[i];
                    ending_array[i] = ending_array[i + 1];
                    ending_array[i + 1] = test;
                    not_git = false;
                }
                if(starting_array[ending_array[i]] == starting_array[ending_array[i + 1]])
                {
                    starting_array[ending_array[i]]--;
                }
            }
            not_git = !not_git;
        }
    }

    public bool check()
    {
        for(int i = 0; i < 10; i++)
        {
            if (ending_array[i] != node_value_array[i])
            {
                return false;
            }
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if(check() == true)
        {
            Debug.Log("DZIA?A!!!!!!!!!!!!!");
        }
    }

    public void Update_Value(int number)
    {
        node_value_array[number] = (node_value_array[number] + 1) % 10;
        Nodes[number].GetComponent<Node_script>().Set_knob_value(starting_array[node_value_array[number]]);
    }

    public override System.Delegate GetFunction(int index)
    {
        return base.GetFunction(index);
    }
}
