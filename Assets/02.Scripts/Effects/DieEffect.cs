using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static Define;
using Cinemachine;

public class DieEffect : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cvCam;
    [SerializeField] private Vector3 pivotOffset;
    [SerializeField] private float amplitudeGain, frequencyGain;
    [SerializeField] private float duration;

    private CinemachineBasicMultiChannelPerlin cBCP;

    private void Awake()
    {
        
        cBCP = cvCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cBCP.m_PivotOffset = Vector3.zero;
        cBCP.m_AmplitudeGain = 0;
        cBCP.m_FrequencyGain = 0;

    }

    public void ShakeEffect()
    {

        StartCoroutine(ShakeCo());
            
    }

    IEnumerator ShakeCo()
    {

        float time = duration;
        cBCP.m_PivotOffset = pivotOffset;

        yield return null;

        while(time > 0)
        {

            cBCP.m_AmplitudeGain = Mathf.Lerp(0, amplitudeGain, time / duration);
            cBCP.m_FrequencyGain = Mathf.Lerp(0, frequencyGain, time / duration);
            time -= Time.deltaTime;

            yield return null;

        }

        yield return null;

        cBCP.m_PivotOffset = Vector3.zero;
        cBCP.m_AmplitudeGain = 0;
        cBCP.m_FrequencyGain = 0;

    }

}
