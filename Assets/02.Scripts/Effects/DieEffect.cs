using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static Define;
using Cinemachine;
using UnityEngine.Rendering.Universal;
using FD.Dev;

public class DieEffect : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cvCam;
    [SerializeField] private Vector3 pivotOffset;
    [SerializeField] private float amplitudeGain, frequencyGain;
    [SerializeField] private float duration;
    [SerializeField] private float delay;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private Light2D light2D;

    private CinemachineBasicMultiChannelPerlin cBCP;

    private void Start()
    {

        cvCam = FindObjectOfType<CinemachineVirtualCamera>();
        cBCP = cvCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        light2D = GameObject.Find("GlobalLight").GetComponent<Light2D>();
        cBCP.m_PivotOffset = Vector3.zero;
        cBCP.m_AmplitudeGain = 0f;
        cBCP.m_FrequencyGain = 0f;

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
        Time.timeScale = 0.1f;
        light2D.intensity -= 0.3f;
        yield return new WaitForSecondsRealtime(delay);

        while (Time.timeScale < 1)
        {

            cBCP.m_AmplitudeGain = Mathf.Lerp(0, amplitudeGain, Time.timeScale / duration);
            cBCP.m_FrequencyGain = Mathf.Lerp(0, frequencyGain, Time.timeScale / duration);
            Time.timeScale += 0.01f;


            yield return new WaitForSecondsRealtime(0.01f);

        }

        yield return null;

        cBCP.m_PivotOffset = Vector3.zero;
        cBCP.m_AmplitudeGain = 0f;
        cBCP.m_FrequencyGain = 0f;

        // 나중에 클리어시 [다음 스테이지로], [메뉴 화면으로] 버튼 띄우기
        GameScene gameScene = Managers.Scene.CurrentScene as GameScene;
        bool isClear = gameScene.StageClear();
        FAED.InvokeDelay(() =>
        {
            if(isClear == false)
            {
                Managers.Scene.LoadScene(Scene.Stage);
            }
            else
            {
                Managers.Scene.LoadScene(Define.Scene.Menu);
            }

        }, 3f);

    }

}
