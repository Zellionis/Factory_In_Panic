///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 06/09/2021 16:21
///-----------------------------------------------------------------

using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    public class NarrationManager : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI box = default;
        [SerializeField] private NarrativeManagerScriptable managerBox = default;
        [SerializeField] private List<GameObject> listDialogueObject = default;

        private DialogueData currentLine = default;

        private void Start()
        {
            managerBox.ResetNumber();
            currentLine = managerBox.CurrentDiscution;
            box.text = currentLine.text;    
        }

        public void Open()
        {
            for (int i = 0; i < listDialogueObject.Count; i++)
            {
                listDialogueObject[i].SetActive(true);
            }
        }

        public void Close()
        {
            Debug.Log("Close");
            for (int i = 0; i < listDialogueObject.Count; i++)
            {
                listDialogueObject[i].SetActive(false);
            }
        }

        public void ShowNextText()
        {

            if (managerBox.CurrentDiscution.lastLine==false) box.text = managerBox.NextLine().text;
            else Close();

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

        public void Load1()
        {
            Open();
            box.text = managerBox.LoadBlock(1).text;
        }

        public void Load2()
        {
            Open();
            box.text = managerBox.LoadBlock(2).text;
        }
    }
}