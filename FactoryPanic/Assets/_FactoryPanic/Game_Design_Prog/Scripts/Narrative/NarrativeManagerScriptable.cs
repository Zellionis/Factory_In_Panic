///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 06/09/2021 15:51
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    [CreateAssetMenu(menuName = "FactoryPanic/NarrativeManagerScriptable")]
    public class NarrativeManagerScriptable : ScriptableObject {
        [SerializeField] public List<BlockOfLines> managerDialogueBlock = default;
        [SerializeField] public List<DialogueData> ManagerRemark = default;
        [SerializeField] public List<DialogueData> ManagerBoost = default;
        [SerializeField] public List<DialogueData> ManagerDoubtful = default;
        private int currentBlockIndex = 0;
        private int previewsRandomIndex = 0;
        public DialogueData CurrentDiscution
        {
            get
            {
                return managerDialogueBlock[currentBlockIndex].CurrentLine;
            }
        }

        public string GetRandomPunchline
        {
            get
            {
                return GetRandomAnswer(ManagerRemark);
            }
        }
        public string GetRandomBoostAnswer
        {
            get
            {
                return GetRandomAnswer(ManagerBoost);
            }
        }
        public string GetRandomDoubtfullAnswer
        {
            get
            {
                return GetRandomAnswer(ManagerDoubtful);
            }
        }

        public DialogueData NextLine()
        {
            return managerDialogueBlock[currentBlockIndex].NextLine();
        }

        public DialogueData LoadBlock(int indexBlock)
        {
            managerDialogueBlock[currentBlockIndex].ResetIndex();
            if (indexBlock < managerDialogueBlock.Count - 1) currentBlockIndex = indexBlock;
            

            return managerDialogueBlock[currentBlockIndex].lines[0];
        }

        public DialogueData LoadBlock()
        {
            managerDialogueBlock[currentBlockIndex].ResetIndex();
            if (currentBlockIndex < managerDialogueBlock.Count - 1) currentBlockIndex++;

            return managerDialogueBlock[currentBlockIndex].lines[0];
        }

        private string GetRandomAnswer(List<DialogueData> list)
        {
            int randomInt = UnityEngine.Random.Range(0, list.Count);


            return list[randomInt].text;
        }

        public void ResetNumber()
        {
            currentBlockIndex = 0;
            for (int i = 0; i < managerDialogueBlock.Count; i++)
            {
                managerDialogueBlock[i].ResetIndex();
            }
        }
        
    }

    [Serializable]
    public struct DialogueData{
         public string text;
         public float durationOfText;
         public Animator sprite;
        public bool lastLine;

        }
}
