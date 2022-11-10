using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static Define;
using Cinemachine;
using UnityEngine.Rendering.Universal;

public class DieEffect : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cvCam;
    [SerializeField] private Vector3 pivotOffset;
    [SerializeField] private float amplitudeGain, frequencyGain;
    [SerializeField] private float duration;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private Light2D light2D;

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

        cBCP.m_PivotOffset = pivotOffset;

        yield return null;
        particle.Play();
        Time.timeScale = 0.2f;

        while(Time.timeScale < 1)
        {

            cBCP.m_AmplitudeGain = Mathf.Lerp(0, amplitudeGain, Time.timeScale / duration);
            cBCP.m_FrequencyGain = Mathf.Lerp(0, frequencyGain, Time.timeScale / duration);
            Time.timeScale += 0.01f;

            light2D.intensity -= 0.01f;
            light2D.intensity = Mathf.Clamp(light2D.intensity, 0.4f, 1);

            yield return new WaitForSecondsRealtime(0.01f);

        }

        yield return null;

        cBCP.m_PivotOffset = Vector3.zero;
        cBCP.m_AmplitudeGain = 0;
        cBCP.m_FrequencyGain = 0;

    }

}
