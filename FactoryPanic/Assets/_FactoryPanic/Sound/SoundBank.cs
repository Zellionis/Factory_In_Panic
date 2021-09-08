///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 07/09/2021 21:02
///-----------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.Sound {

    [CreateAssetMenu(menuName = "FactoryPanic/SoundBank")]
    public class SoundBank : ScriptableObject {
        [SerializeField] private List<AudioClip> listOfSound = default;
        private int previousRandom = default;

        public AudioClip GetSoundAt(int index)
        {
            return listOfSound[index];
        }

        public AudioClip GetRandomSound()
        {
            int randomInt = UnityEngine.Random.Range(0, listOfSound.Count);
            while (randomInt == previousRandom)
            {
                randomInt = UnityEngine.Random.Range(0, listOfSound.Count);
            }
            previousRandom = randomInt;
            return listOfSound[randomInt];
        }
    }
}
