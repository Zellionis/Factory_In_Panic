///-----------------------------------------------------------------
/// Author : Julien Cagnoncle
/// Date : 09/09/2021 18:54
///-----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {
	public class SpeedChangement : MonoBehaviour {
		private static SpeedChangement instance;
		public static SpeedChangement Instance { get { return instance; } }

		[SerializeField, Range(0F, 1F)] private float valueSpeed = default;
		[SerializeField, Range(0F, 5F)] private float timeToSwitch = default;
		[SerializeField] private Animator animator = default;
		public float ValueSpeed
        {
            get
            {
				return valueSpeed;
            }
        }

        private void Start()
        {
			animator.speed = valueSpeed;
        }

        private void Awake(){
			if (instance){
				Destroy(gameObject);
				return;
			}
			
			instance = this;
		}

		public void Stop()
        {
			animator.speed = 0;
        }

		public void Play()
        {
			animator.speed = valueSpeed;
        }

		public void TransitionToStop()
        {
			StartCoroutine(Transition(valueSpeed, 0));
        }

		public void TransitionToPlay()
        {
			StartCoroutine(Transition(0, valueSpeed));
		}

		private IEnumerator Transition(float from, float to)
        {
			float index = 0;
			float ratio = 1 / timeToSwitch;

            while (index<1)
            {
				index = ratio * Time.deltaTime;
				animator.speed = Mathf.Lerp(from, to, index);
				yield return null;
			}
        }
		
		private void OnDestroy(){
			if (this == instance) instance = null;
		}
	}
}