///-----------------------------------------------------------------
/// Author : Julien Cagnoncle
/// Date : 09/09/2021 19:37
///-----------------------------------------------------------------

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {
	public class Loader : MonoBehaviour {
		private static Loader instance;
		public static Loader Instance { get { return instance; } }
		
		private void Awake(){
			if (instance){
				Destroy(gameObject);
				return;
			}
			
			instance = this;
		}
		
		public void LoadTitle()
        {
			SceneManager.LoadScene("_FactoryPanic/Scenes/TitleCard", LoadSceneMode.Single);
		}

		public void LoadCredit()
		{
			SceneManager.LoadScene("_FactoryPanic/Scenes/Credit", LoadSceneMode.Single);
		}

		private void OnDestroy(){
			if (this == instance) instance = null;
		}
	}
}