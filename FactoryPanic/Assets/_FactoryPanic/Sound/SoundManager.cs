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

		[Space(20)]

		[SerializeField] private SoundBank robotBank = default;
		[SerializeField] private AudioSource robotSource = default;
		[SerializeField] private AudioSource handSource = default;

		[Space(20)]

		[SerializeField] private AudioSource bgmSource = default;
		[SerializeField,Range(0.5F,1.5F)] private float pitchMultiplier = 1.2F;
		[SerializeField] private AudioSource backgroundNoise = default;
		[SerializeField, Range(1F, 5F)] private float soundReductionMultiplier = 1.2F;


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

		public void SpeedUpMusic()
        {
			bgmSource.pitch*= pitchMultiplier;
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

		public void ChangeVolumeBgm(bool reduce)
        {
			if (reduce) 
			{ 
				backgroundNoise.volume /= soundReductionMultiplier;
				bgmSource.volume /= soundReductionMultiplier;
			}
			else 
			{
				bgmSource.volume *= soundReductionMultiplier;
				backgroundNoise.volume *= soundReductionMultiplier; 
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

		public void PlayGrab()
        {
			if (!robotSource.isPlaying)
			{
				robotSource.clip = robotBank.GetRandomSound();
				robotSource.Play();
			}

			if (!handSource.isPlaying) handSource.Play();
		}

		private void OnDestroy(){
			if (this == instance) instance = null;
		}
	}
}