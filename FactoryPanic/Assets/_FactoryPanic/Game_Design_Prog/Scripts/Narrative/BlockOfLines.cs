///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 06/09/2021 21:37
///-----------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    [CreateAssetMenu(menuName = "FactoryPanic/BlockOfLines")]
    public class BlockOfLines : ScriptableObject {
        [SerializeField] public List<DialogueData> lines;
        private int currentLineIndex = 0;

        public DialogueData CurrentLine
        {
            get { return lines[currentLineIndex]; }
        }

        public DialogueData NextLine()
        {
            if (currentLineIndex < lines.Count - 1)currentLineIndex++;
                
            return lines[currentLineIndex];

        }

        public void ResetIndex()
        {
            currentLineIndex = 0;
        }
    }
}
