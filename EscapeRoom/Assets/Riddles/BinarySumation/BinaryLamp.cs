using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BinarySumation
{
    public class BinaryLamp : FunctionGettable
    {
        public BinaryWire[] srcWires;
        public BinaryWire[] dstWires; //one goes downwards, second goes left

        public bool on = false;

        public Material matOn, matOff;
        Renderer renderer;

        public bool outputLamp = false;

        private void Start()
        {
            renderer = GetComponent<Renderer>();

            if (on)
            {
                renderer.material = matOn;
            }
            else
            {
                renderer.material = matOff;
            }

        }

        private void Update()
        {
            if (gameObject.name.Equals("Sphere.017"))
            {
                int a = 2;
            }
            if (!outputLamp)
            {
                int sum = 0;
                foreach (var src in srcWires)
                {
                    if (src.on) sum++;
                }

                if (on) sum++;
                LightWires(sum);
            }
            else
            {
                if (srcWires[0].on)
                {
                    renderer.material = matOn;
                }
                else
                {
                    renderer.material = matOff;
                }
            }
        }


        public void SwitchState(bool valIgnored)
        {
            on = !on;
            if (on)
            {
                renderer.material = matOn;
            }
            else
            {
                renderer.material = matOff;
            }

        }

        void LightWires(int sum)
        {
            if (dstWires.Length > 0)
            {
                switch (sum)
                {
                    case 0:
                        foreach (var wire in dstWires)
                        {
                            wire.SetOn(false);
                        }
                        break;
                    case 1:
                        dstWires[0].SetOn(true);
                        if (dstWires.Length > 1)
                        {
                            dstWires[1].SetOn(false);
                        }
                        break;
                    case 2:

                        dstWires[0].SetOn(false);
                        if (dstWires.Length > 1)
                        {
                            dstWires[1].SetOn(true);
                        }
                        break;
                }
            }

        }

        public bool GetOn()
        {
            return on;
        }
        
        public override Delegate GetFunction(int index)
        {
            return ((Action<bool>)SwitchState);
            
        }
    }
}
