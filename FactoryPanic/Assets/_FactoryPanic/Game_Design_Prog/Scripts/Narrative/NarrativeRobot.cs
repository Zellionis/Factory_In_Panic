///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 07/09/2021 14:56
///-----------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    [CreateAssetMenu(menuName = "FactoryPanic/NarrativeRobot")]
    public class NarrativeRobot : ScriptableObject {
        [SerializeField] private ClassRobot personality = default;
        [SerializeField] private ClassRobot body = default;
        [SerializeField] public List<DialogueData> lines = default;

        public ClassRobot Body { get { return body; } }
        public ClassRobot Personality { get { return personality; } }

        public DialogueData GetRandomLine()
        {
            int randomInt = UnityEngine.Random.Range(0, lines.Count);
            return lines[randomInt];
        }
        public DialogueData GetLineAt(int i)
        {
           
            return lines[i];
        }
    }
}
