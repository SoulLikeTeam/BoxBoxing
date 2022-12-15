using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FD.Feature
{

    public class FAED_DelayInvoke : MonoBehaviour
    {

        public void SetDelay(Action action, float delayTime)
        {

            StartCoroutine(DelayCo(action, delayTime));

        }

        public void SetDelayReal(Action action, float delayTime)
        {

            StartCoroutine(DelayCoReal(action, delayTime));

        }

        public void SetDelayFunc(Action action, Func<bool> func)
        {

            StartCoroutine(DelayCoFunc(action, func));

        }

        IEnumerator DelayCo(Action action, float delayTime)
        {

            yield return new WaitForSeconds(delayTime);
            try
            {

                action?.Invoke();

            }
            catch (Exception e)
            {

                Debug.LogWarning($"FAED.InvoekDelayError : {e.Message}");

            }

        }

        IEnumerator DelayCoReal(Action action, float delayTime)
        {

            yield return new WaitForSecondsRealtime(delayTime);
            try
            {

                action?.Invoke();

            }
            catch (Exception e)
            {

                Debug.LogWarning($"FAED.InvoekDelayRealError : {e.Message}");

            }

        }

        IEnumerator DelayCoFunc(Action action, Func<bool> func)
        {

            yield return new WaitUntil(func);
            try
            {

                action?.Invoke();

            }
            catch (Exception e)
            {

                Debug.LogWarning($"FAED.InvoekDelayRealError : {e.Message}");

            }

        }

    }

}
