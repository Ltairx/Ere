using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ere.Riddles.RleCompression
{
    public class RleCompression : Riddle
    {
        [field: SerializeField] private LockedBox box;
        [field: SerializeField] private GameObject puzzle;
        private List<SnappingHolder> puzzles;

        protected override void Start()
        {
            base.Start();

            if (puzzle is null)
            {
                Debug.LogError("There is no puzzles parent assigned in rle riddle");
                return;
            }
            
            puzzles = puzzle.GetComponentsInChildren<SnappingHolder>().ToList();
        }

        public override Delegate GetFunction(int index)
        {
            if (index != 15) return (Action<(int, int)>)box.CheckPassword;
            
            return (Action<float>)ResetPuzzles;
        }

        private void ResetPuzzles(float notUsedArg)
        {
            puzzles.ForEach(x => x.ResetPosition());
        }
        
        public override float GetSolvePercentage()
        {
            return box.CheckPercentage();
        }
    }
}
