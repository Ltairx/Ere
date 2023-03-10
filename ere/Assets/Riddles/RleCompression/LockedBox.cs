using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ere.Riddles.RleCompression
{
    public class LockedBox : MonoBehaviour
    {
        private bool locked = true;
        [field: SerializeField] private List<int> password;
        [field: SerializeField] private float openAngle;
        private List<int> result = new();

        private void Start()
        {
            if(password.Count == 0)
                password = new List<int> { 5, 3, 4, 5, 7, 2};

            if (openAngle == 0)
                openAngle = 30;
            
            for (var i = 0; i < password.Count; i++)
            {
                result.Add(5);
            }
        }

        public void CheckPassword((int, int) indexAndNumber) 
        {
            result[indexAndNumber.Item1] = indexAndNumber.Item2;
            
            if (password.OrderBy(x => x).SequenceEqual(result.OrderBy(x => x)))
            {
                Open();
            }
        }
        
        private void Open()
        {
            if (!locked) return;
            
            StartCoroutine("RotateLid");
            Debug.Log("otworzone");
            locked = false;
        }

        private IEnumerator RotateLid()
        {
            for (var i = 0; i < 10; i++)
            {
                transform.Rotate(openAngle/10, 0f, 0f);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }    
}

