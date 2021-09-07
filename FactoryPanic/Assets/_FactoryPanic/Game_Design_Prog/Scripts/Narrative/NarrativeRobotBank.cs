///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 07/09/2021 15:01
///-----------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    [CreateAssetMenu(menuName = "FactoryPanic/NarrativeRobotBank")]
    public class NarrativeRobotBank : ScriptableObject {
        [SerializeField] private List<NarrativeRobot> bank = default;

        public DialogueData GetRandomLine(ClassRobot body, ClassRobot personality)
        {
            for (int i = 0; i < bank.Count; i++)
            {
                if((body == bank[i].Body) && (personality == bank[i].Personality))
                {
                    return bank[i].GetRandomLine();
                }
            }
            return new DialogueData();
        }
    }
}
