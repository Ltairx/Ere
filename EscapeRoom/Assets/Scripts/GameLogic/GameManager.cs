using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameManager
{

    public class GameManager : MonoBehaviour
    {
        bool playerInLastRoom = false;
        public GameObject trophe;
        List<Room> room = new List<Room>();


        /// <summary>
        /// returns value betwwen 0 and 1
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public float CalcDegreeKnowledge(Degree degree)
        {
            float knowledge = room.Select(x => x[degree].GetSolvePercentage()).Sum();
            knowledge /= room.Count();
            return knowledge;
        }


        /// <summary>
        /// Called by the clock to finish the game, and move the player to the last room. when run out of time.
        /// 
        /// </summary>
        public void EndGame()
        {
            //hide to trophe

            StartCoroutine(DarkTeleport());
        }

        IEnumerator DarkTeleport()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            float startTime = Time.time;
            float darkTime = 1f;

            float lerpVal;
            
            while (Time.time < startTime + darkTime)
            {
                lerpVal = Mathf.Lerp(1, 0, (Time.time - startTime) / darkTime);
                //TODO darken light source; here
                yield return null;
            }


            //move the player to the gameManager. As simple as that XD
            player.transform.position = transform.position;
            trophe.SetActive(false);



            startTime = Time.time;
            while (Time.time < startTime + darkTime)
            {
                lerpVal = Mathf.Lerp(0, 1, (Time.time - startTime) / darkTime);
                //TODO darken light source; here
                yield return null;
            }
        }


        /// <summary>
        /// called by trigger when player was moved to the last room or he physicaly entered
        /// </summary>
        public void PlayerInLastRoom()
        {
            if (!playerInLastRoom)
            {
                //close Door
                //Tell the clock to stop counting if it hasn't stopped
                ShowScore();

                playerInLastRoom = true;
            }
        }
        /// <summary>
        /// calculate and display Score when the game has finished
        /// </summary>
        private void ShowScore()
        {

        }
    }
}