///-----------------------------------------------------------------
/// Author : Julien Cagnoncle
/// Date : 07/09/2021 20:56
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.Sound {
	public class SoundManager : MonoBehaviour {
		private static SoundManager instance;
		public static SoundManager Instance { get { return instance; } }

		[SerializeField] private SoundBank managerVoiceBank = default;
		[SerializeField] private AudioSource managerVoiceSource = default;

		[Space(20)]

		[SerializeField] private SoundBank clickVoiceBank = default;
		[SerializeField] private AudioSource clickSource = default;
		[SerializeField] private SoundBank clickVoiceBackBank = default;

		[Space(20)]

		[SerializeField] private SoundBank completedBank = default;
		[SerializeField] private AudioSource completedSource = default;

		[Space(20)]

		[SerializeField] private AudioSource lostSource = default;

		private void Awake(){
			if (instance){
				Destroy(gameObject);
				return;
			}
			
			instance = this;
		}

		public void PlayCompletedSound()
        {
			if (!completedSource.isPlaying)
			{
				completedSource.clip = completedBank.GetRandomSound();
				completedSource.Play();
			}
		}
		
		public void PlayClickEnter()
        {
			if (!clickSource.isPlaying)
			{
				clickSource.clip = clickVoiceBank.GetRandomSound();
				clickSource.Play();
			}
		}

		public void PlayClickLeave()
		{
			if (!clickSource.isPlaying)
			{
				clickSource.clip = clickVoiceBackBank.GetSoundAt(0);
				clickSource.Play();
			}
		}

		public void PlayClickLost()
        {
			if (!lostSource.isPlaying)
			{
				lostSource.Play();
			}
		}

		public void PlayVoiceManager()
		{

			if (!managerVoiceSource.isPlaying)
			{
				managerVoiceSource.clip = managerVoiceBank.GetRandomSound();
				managerVoiceSource.Play();
			}
		}

		private void OnDestroy(){
			if (this == instance) instance = null;
		}
	}
}