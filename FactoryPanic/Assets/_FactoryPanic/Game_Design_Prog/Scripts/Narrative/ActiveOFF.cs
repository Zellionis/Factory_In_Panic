///-----------------------------------------------------------------
///   Author : Julien Cagnoncle                    
///   Date   : 08/09/2021 22:08
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative {

    public class ActiveOFF : MonoBehaviour {

       public void SetActiveOff()
        {
            gameObject.SetActive(false);
        }
    }
}