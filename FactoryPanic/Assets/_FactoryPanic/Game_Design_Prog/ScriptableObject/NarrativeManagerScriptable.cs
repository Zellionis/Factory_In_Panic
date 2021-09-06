///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 06/09/2021 15:51
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg {

    [CreateAssetMenu(menuName = "FactoryPanic/NarrativeManagerScriptable")]
    public class NarrativeManagerScriptable : ScriptableObject {
        [SerializeField] public List<DialogueData> ManagerDialogueBasic = default;
        [SerializeField] public List<DialogueData> ManagerRemark = default;
        [SerializeField] public List<DialogueData> ManagerBoost = default;
        [SerializeField] public List<DialogueData> ManagerDoubtful = default;
        private int index = 0;
        private int randomIndex = 0;
        public string CurrentDiscution
        {
            get
            {
                return ManagerDialogueBasic[index].text;
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

        public string NextDiscution()
        {
            if(index < ManagerDialogueBasic.Count-1) index++;
            return ManagerDialogueBasic[index].text;
        }

        private string GetRandomAnswer(List<DialogueData> list)
        {
            int randomInt = UnityEngine.Random.Range(0, list.Count);


            return list[randomInt].text;
        }

        public void ResetNumber()
        {
            index = 0;
        }
        
    }

    [Serializable]
    public struct DialogueData{
         public string text;
         public float durationOfText;
         public Animator sprite;

        }
}
