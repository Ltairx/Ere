using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace BinarySumation
{
    public class BinarySumationScript : Riddle
    {
        [SerializeField] BinaryLamp[] solution;
        [SerializeField]BinaryLamp[] output;

        bool solved = false;

        // Update is called once per frame
        void Update()
        {
            if (!solved)
            {
                int correctHits = solution.Select((solution, index) => (solution.on == output[index].on)? 1:0).Sum(x=> x);
                if(correctHits == solution.Length)
                {
                    solved = true;
                }                
            }

            Debug.Log(GetSolvePercentage());
        }

        public override Delegate GetFunction(int index)
        {
            return base.GetFunction(index);
        }

        public override float GetSolvePercentage()
        {
            if (solved) return 1f;
            int correctHits = solution.Select((sol, index) => (sol.on == output[index].on) ? 1 : 0).Sum(x => x);            

            if (correctHits <= 1)
            {
                return 0f;
            }

            return (float) (correctHits)/6;

        }
    }
}
