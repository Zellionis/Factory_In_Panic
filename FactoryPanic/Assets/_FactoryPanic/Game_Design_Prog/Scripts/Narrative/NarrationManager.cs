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
        [SerializeField] private Animator face = default;
        [SerializeField] private HUD blackscreen = default;
        [SerializeField] private Factory factory = default;
        [SerializeField] private List<GameObject> effect= default;
        [SerializeField] private List<Animator> rouage= default;

        private bool IsDisplaying = false;
        private Coroutine currentCoroutine = default;
        private DialogueData currentLine = default;

        [SerializeField] private bool textShowed = true;
        public static bool textShowedStatic = true;

        private int previousInt = 5;

        private Face currentExpression = Face.Panic;

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
            textShowedStatic = true;
            for (int i = 0; i < listDialogueObject.Count; i++)
            {
                listDialogueObject[i].SetActive(true);
            }
        }

        public void Close()
        {
            textShowed = false;
            textShowedStatic = false;
            for (int i = 0; i < listDialogueObject.Count; i++)
            {
                listDialogueObject[i].SetActive(false);
            }
            if (currentExpression != Face.Neutral) face.SetTrigger("Neutral");
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
                    if (managerBox.CurrentChapter == 1) 
                    {
                        SoundManager.Instance.SpeedUpMusic();
                        factory.UpdateHUD();
                        Load3(); 
                    }
                    else if (managerBox.CurrentChapter == 5)
                    {
                        blackscreen.Hide();
                        Close();
                    }
                    else Close();
                }
            }
            else
            {
                IsDisplaying = false;
                box.text = currentLine.text;
                StopCoroutine(currentCoroutine);
                currentCoroutine = default;
                SoundManager.Instance.ChangeVolumeBgm(false);
                face.SetInteger("ID", 5);
                currentExpression = currentLine.expression;
            }


        }

        private IEnumerator SlowText()
        {
            SoundManager.Instance.ChangeVolumeBgm(true);
            if(currentLine.expression!=currentExpression)face.SetTrigger(currentLine.expression.ToString());
            currentExpression = currentLine.expression;
            foreach (char letter in currentLine.text.ToCharArray())
            {
                if (!(letter.ToString() == " "))
                {
                    SoundManager.Instance.PlayVoiceManager();
                    face.SetInteger("ID", RandomInt());
                }
                else
                {
                    face.SetInteger("ID", 5);
                }
                box.text += letter;
                yield return new WaitForSeconds(currentLine.speed);

            }
            face.SetInteger("ID", 5);
            IsDisplaying = false;
            SoundManager.Instance.ChangeVolumeBgm(false);
        }

        public int RandomInt()
        {
            int random = Random.Range(0, 4);
            while (random == previousInt)
            {
                random = Random.Range(0, 4);
            }
            previousInt = random;
            return previousInt;
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
            for (int i = 0; i < effect.Count; i++)
            {
                effect[i].SetActive(true);
            }
            for (int i = 0; i < rouage.Count; i++)
            {
                rouage[i].speed *= 8F;
            }
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
        public void Load8()
        {
            Open();
            StartText(managerBox.LoadBlock(7));
        }
    }

    public enum  Face
    {
        Happy,
        Panic,
        Neutral,
    }
}