///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 06/09/2021 16:21
///-----------------------------------------------------------------

using TMPro;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    public class NarrationManager : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI Box = default;
        [SerializeField] private NarrativeManagerScriptable ManagerBox = default;

        private void Start()
        {
            ManagerBox.ResetNumber();
            Box.text = ManagerBox.CurrentDiscution;    
        }

        public void ShowNextText()
        {
            Box.text = ManagerBox.NextDiscution();
        }

        public void ShowNextPunchline()
        {
            Box.text = ManagerBox.GetRandomPunchline;
        }

        public void ShowNextBoost()
        {
            Box.text = ManagerBox.GetRandomBoostAnswer;
        }

        public void ShowNextDoubt()
        {
            Box.text = ManagerBox.GetRandomDoubtfullAnswer;
        }
    }
}