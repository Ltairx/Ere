using System;
using UnityEngine;

namespace Ere.Riddles.RleCompression
{
    public class RleCompression : Riddle
    {
        [field: SerializeField] private LockedBox box;
        
        public override Delegate GetFunction(int index)
        {
            return (Action<(int, int)>)box.CheckPassword;
        }
    }
}
