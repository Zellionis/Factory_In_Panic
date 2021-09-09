///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 07/09/2021 12:47
///-----------------------------------------------------------------

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    public class HUD : MonoBehaviour {

        [SerializeField] private GameObject pauseScreen = default;
        [SerializeField] private Animator animatorPause = default;
        [SerializeField] private Animator blackScreen = default;
        [SerializeField] private TextMeshProUGUI counter = default;
        static public bool stopped = false;

        public void Pause()
        {
            pauseScreen.SetActive(true);
            stopped = true;
            animatorPause.SetBool("Open", true);
        }

        public void Show()
        {
            blackScreen.SetTrigger("Show");
        }

        public void Hide()
        {
            blackScreen.SetTrigger("Hide");
        }

        public void Continue()
        {
            stopped = false;
            animatorPause.SetBool("Open", false);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void TitleScreen()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("_FactoryPanic/Scenes/TitleCard", LoadSceneMode.Single);
        }

        public void setCounter(int i,int maxRobot)
        {
            counter.text = i + "/" + maxRobot;
        }
    }
}