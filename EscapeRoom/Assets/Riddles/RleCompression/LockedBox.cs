using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Ere.Riddles.RleCompression
{
    public class LockedBox : MonoBehaviour
    {
        private bool locked = true;
        [field: SerializeField] private List<int> password;
        [field: SerializeField] private float openAngle;
        [field: SerializeField] private TextMeshPro codeText;
        private List<int> result = new List<int>();

        private bool riddleTouched = false;

        private void Start()
        {
            if(codeText == null)
            {
                Debug.LogWarning("rle nie posiada miejsca na wyswietlenie kodu w pudelku");
            }

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
            riddleTouched = true;
            result[indexAndNumber.Item1] = indexAndNumber.Item2;
            if (password.OrderBy(x => x).SequenceEqual(result.OrderBy(x => x)))
            {
                Open();
            }
        }

        public float CheckPercentage()
        {
            if (!riddleTouched)
            {
                return 0;
            }

            var max = password.Count;
            var min = 0;

            for (int i = 0; i < max; i++)
            {
                if (result[i] == password[i]) min++;
            }

            return (float)min / max;
        }
        
        private void Open()
        {
            if (!locked) return;
            
            StartCoroutine("RotateLid");
            Debug.Log("otworzone");
            locked = false;

            if(codeText != null)
            {
                codeText.gameObject.SetActive(true);
            }
        }

        private IEnumerator RotateLid()
        {
            for (var i = 0; i < 10; i++)
            {
                transform.Rotate(openAngle/10, 0f, 0f);
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 0.023f);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }    
}

