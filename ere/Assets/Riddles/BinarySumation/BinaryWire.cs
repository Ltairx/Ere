using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BinarySumation
{
    public class BinaryWire : MonoBehaviour
    {
        public bool on = false;

        public Material matOn, matOff;
        Renderer renderer;


        private void Start()
        {
            renderer = GetComponent<Renderer>();
        }

        public void SetOn(bool state)
        {
            on = state;
            if (on)
            {
                renderer.material= matOn;
            }
            else
            {
                renderer.material= matOff;
            }
        }
    }
}