using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public enum Degree
    {
        COMPUTER_SCIENCE,
        AUTOMATICS,
        DEGREES_NUMBER
    }

    public class Room : MonoBehaviour
    {
        //dictionary can't be public, so the riddle must add itself
        private Dictionary<Degree, Riddle> riddles = new Dictionary<Degree, Riddle>();

        public bool doorToOpen = false;
        //public Door door; //if doorToPen = true, it will open door automaticaly ---------------------------

        
        public Riddle this[Degree degree]
        {
            get { return riddles[degree]; }
            set { riddles[degree] = value; }
        }
        

        /// <summary>
        /// called by the riddle itself in order to add it the room.
        /// </summary>
        /// <param name="riddle"></param>
        /// <param name="degree"></param>
        public void AddRiddle(Riddle riddle, Degree degree)
        {
            riddles.Add(degree, riddle);        
        }


        /// <summary>
        /// called by the riddle itself.
        /// Informs the Room that the riddle has been solved.
        /// Mostly used to open doors if needed XD.
        /// </summary>
        public void RiddleSolved()
        {
            if (doorToOpen)
            {
                //door.Open(); ----------------------------------------------------------
            }
        }

    }
}