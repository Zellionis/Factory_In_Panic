///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 06/09/2021 16:21
///-----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    public class NarrationManager : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI box = default;
        [SerializeField] private NarrativeManagerScriptable managerBox = default;
        [SerializeField] private List<GameObject> listDialogueObject = default;

        private bool IsDisplaying = false;
        private Coroutine currentCoroutine = default;
        private DialogueData currentLine = default;

        private void Start()
        {
            managerBox.ResetNumber();
            StartText(managerBox.CurrentDiscution);
            
        }

        private void StartText(DialogueData dialogue)
        {
            currentLine = dialogue;
            IsDisplaying = true;
            box.text = "";
            currentCoroutine = StartCoroutine(SlowText());
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
            if (!IsDisplaying)
            {
                if (managerBox.CurrentDiscution.lastLine == false)
                {
                    StartText(managerBox.NextLine());
                }
                else Close();
            }
            else
            {
                IsDisplaying = false;
                box.text = currentLine.text;
                StopCoroutine(currentCoroutine);
                currentCoroutine = default;
            }


        }

        private IEnumerator SlowText()
        {
            foreach (char letter in currentLine.text.ToCharArray())
            {
                box.text += letter;
                yield return new WaitForSeconds(currentLine.speed);

            }
            IsDisplaying = false;
        }

        public void ShowNextPunchline()
        {
            StartText(managerBox.GetRandomPunchline);
        }

        public void ShowNextBoost()
        {
            StartText(managerBox.GetRandomBoostAnswer);
        }

        public void ShowNextDoubt()
        {
            StartText(managerBox.GetRandomDoubtfullAnswer);
        }

        public void Load1()
        {
            Open();
            StartText(managerBox.LoadBlock(1));
        }

        public void Load2()
        {
            Open();
            StartText(managerBox.LoadBlock(2));
        }
    }
}