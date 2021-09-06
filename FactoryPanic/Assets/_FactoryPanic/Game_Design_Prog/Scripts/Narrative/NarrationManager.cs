///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 06/09/2021 16:21
///-----------------------------------------------------------------

using TMPro;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    public class NarrationManager : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI box = default;
        [SerializeField] private NarrativeManagerScriptable managerBox = default;
        [SerializeField] private GameObject skipButton = default;

        private void Start()
        {
            managerBox.ResetNumber();
            box.text = managerBox.CurrentDiscution;    
        }

        public void Open()
        {
            
        }

        public void ShowNextText()
        {
            box.text = managerBox.NextDiscution();
        }

        public void ShowNextPunchline()
        {
            box.text = managerBox.GetRandomPunchline;
        }

        public void ShowNextBoost()
        {
            box.text = managerBox.GetRandomBoostAnswer;
        }

        public void ShowNextDoubt()
        {
            box.text = managerBox.GetRandomDoubtfullAnswer;
        }
    }
}