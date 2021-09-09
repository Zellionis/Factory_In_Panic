///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 07/09/2021 11:57
///-----------------------------------------------------------------

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    public class TittleScreen : MonoBehaviour {
        public void StartGame()
        {
            SceneManager.LoadScene("_FactoryPanic/Scenes/Narration_test", LoadSceneMode.Single);
        }

        public void Close()
        {
            GetComponent<Animator>().SetTrigger("Close");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}