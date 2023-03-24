using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameManager
{

    public class GameManager : MonoBehaviour
    {
        List<Room> room = new List<Room>();


        public float CalcDegreeKnowledge(Degree degree)
        {
            float knowledge = room.Select(x => x[degree].GetSolvePercentage()).Sum();
            knowledge /= room.Count();
            return knowledge;
        }


        /// <summary>
        /// Called by the clock to finish the game, and summ up the score.
        /// </summary>
        public void EndGame()
        {
        }
    }
}