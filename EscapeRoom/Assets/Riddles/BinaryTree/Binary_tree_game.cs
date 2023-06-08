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
    bool solved = false;
    bool touched = false;
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();

        int[] tab = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int randomNumber;
        int next;
        bool found = true;
        for (int i = 0; i < 10; i++)
        {
            while (found)
            {
                randomNumber = Random.Range(1, 99);
                next = randomNumber / 10;
                if (tab[next] != -1)
                {
                    tab[next] = -1;
                    found = false;
                    starting_array[i] = randomNumber;
                    ending_array[i] = i;
                    node_value_array[i] = i;
                }
            }
            found = true;
            
            
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

    public float solved_percent()
    {
        float percent = 0;
        if(touched == true)
        {
            for (int i = 0; i < 10; i++)
            {
                if (ending_array[i] == node_value_array[i])
                {
                    percent += 0.1f;
                }
            }
        }
       
        return percent;
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
            //Debug.Log("DZIA£A!!!!!!!!!!!!!");
            solved = true;
            this.OnSolve();
        }
        //Debug.Log("Procenty" + solved_percent());
    }

    public override float GetSolvePercentage()
    {
       if (solved) return 1f;

       return solved_percent();
    }

    public void Update_Value(int number)
    {
        node_value_array[number] = (node_value_array[number] + 1) % 10;
        Nodes[number].GetComponent<Node_script>().Set_knob_value(starting_array[node_value_array[number]]);
    }

    public void In_progress()
    {
        touched = true;
    }

    public override System.Delegate GetFunction(int index)
    {
        return base.GetFunction(index);
    }
}
