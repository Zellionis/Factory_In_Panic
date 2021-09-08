///-----------------------------------------------------------------
/// Author : Julien Cagnoncle
/// Date : 08/09/2021 14:05
///-----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg {
	public class ScreenShake : MonoBehaviour {
		private static ScreenShake instance;
		public static ScreenShake Instance { get { return instance; } }

		[SerializeField] private float duration = default;
		[SerializeField,Range(0.05F,0.1F)] private float maxIntensity = default;
		[SerializeField] private AnimationCurve curve = default;
		[SerializeField] private bool lockX = default;
		[SerializeField] private bool lockY = default;
		[SerializeField] private AudioSource soundEffect = default;

		private void Awake(){
			if (instance){
				Destroy(gameObject);
				return;
			}
			
			instance = this;
		}

        private void Start()
        {
			TriggerScreenShake();
        }

        public void TriggerScreenShake()
        {
			StartCoroutine(Shake());
        }
		
		private IEnumerator Shake()
        {
			Vector3 originPos = transform.localPosition;
			float time = 0;
			float index = 0;
			float ratio =1/duration;
			soundEffect.Play();
            while (time <= duration)
            {
				float x = 0;
				float y = 0;

				if (!lockX) x = Random.Range(-1F, 1F)*(curve.Evaluate(index)* maxIntensity);
				if (!lockY) y = Random.Range(-1F, 1F)*(curve.Evaluate(index)* maxIntensity);

				transform.position = originPos + new Vector3(x, y, originPos.z);
				index += ratio * Time.deltaTime;
				time += Time.deltaTime;
				yield return null;
			}
			transform.position = originPos;

			
        } 
		
		private void OnDestroy(){
			if (this == instance) instance = null;
		}
	}
}