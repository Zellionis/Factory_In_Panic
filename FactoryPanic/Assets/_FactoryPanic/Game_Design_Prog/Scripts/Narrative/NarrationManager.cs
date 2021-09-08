///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 06/09/2021 16:21
///-----------------------------------------------------------------

using Com.IsartDigital.FactoryPanic.Sound;
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

        private bool textShowed = true;
        public bool TextShowed
        {
            get
            {
                return textShowed;
            }
        }

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
            textShowed = true;
            for (int i = 0; i < listDialogueObject.Count; i++)
            {
                listDialogueObject[i].SetActive(true);
            }
        }

        public void Close()
        {
            textShowed = false;
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
                else
                {
                    if (managerBox.CurrentChapter == 1) Load3();
                    else Close();
                }
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
                if (!(letter.ToString() == " ")) SoundManager.Instance.PlayVoiceManager();
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
            StartText(managerBox.LoadBlock(0));
        }

        public void Load2()
        {
            Open();
            StartText(managerBox.LoadBlock(1));
        }

        public void Load3()
        {
            Open();
            StartText(managerBox.LoadBlock(2));
            ScreenShake.Instance.TriggerScreenShake();
        }
        public void Load4()
        {
            Open();
            StartText(managerBox.LoadBlock(3));
        }
        public void Load5()
        {
            Open();
            StartText(managerBox.LoadBlock(4));
        }
        public void Load6()
        {
            Open();
            StartText(managerBox.LoadBlock(5));
        }
        public void Load7()
        {
            Open();
            StartText(managerBox.LoadBlock(6));
        }
    }
}