using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FD.Feature
{

    public class FAED_Feature : MonoBehaviour
    {
             
        public void SetDelay(Action action, float delayTime)
        {

            StartCoroutine(DelayCo(action, delayTime));

        }

        public void SetDelayReal(Action action, float delayTime)
        {

            StartCoroutine(DelayCoReal(action, delayTime));

        }

        IEnumerator DelayCo(Action action, float delayTime)
        {

            yield return new WaitForSeconds(delayTime);
            action?.Invoke();

        }

        IEnumerator DelayCoReal(Action action, float delayTime)
        {

            yield return new WaitForSecondsRealtime(delayTime);
            action?.Invoke();

        }

    }

}
