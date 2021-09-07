///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 07/09/2021 12:47
///-----------------------------------------------------------------

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    public class HUD : MonoBehaviour {

        [SerializeField] private GameObject pauseScreen = default;

        public void Pause()
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }

        public void Continue()
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
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
    }
}