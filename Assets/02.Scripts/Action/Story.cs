using DG.Tweening;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{

    [SerializeField] private GameObject storyObj;
    [SerializeField] private bool isStart = true;
    [SerializeField] private Image fadeImage;

    private bool isCool = true;

    private int _index = 0;

    public void ImageMove(int index)
    {

        if (isCool == false) return;

        StartCoroutine(SC());

        switch (index)
        {
            case 0:
                break;
            case 1:
                storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 0, 0), 0.5f);
                break;
            case 2:
                storyObj.transform.DOMove(storyObj.transform.position + new Vector3(1920, 1080, 0), 0.5f);
                break;
            case 3:
                storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 0, 0), 0.5f);
                break;
            case 4:
                storyObj.transform.DOMove(storyObj.transform.position + new Vector3(1920, 1080, 0), 0.5f);
                break;
            case 5:
                storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 0, 0), 0.5f);
                break;
            case 6:
                storyObj.transform.DOMove(storyObj.transform.position + new Vector3(1920, 1080, 0), 0.5f);
                break;
            case 7:
                storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 0, 0), 0.5f);
                break;
            case 8:
                storyObj.transform.DOMove(storyObj.transform.position + new Vector3(1920, 1080, 0), 0.5f);
                break;
            case 9:
                storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 0, 0), 0.5f);
                break;
            case 10:
                storyObj.transform.DOMove(storyObj.transform.position + new Vector3(1920, 1080, 0), 0.5f);
                break;
            case 11:
                storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 0, 0), 0.5f);
                break;
            default:
                if (isStart)
                {
                    Managers.Scene.LoadScene(Define.Scene.Menu);
                }
                else
                {
                    Managers.Scene.LoadScene(Define.Scene.Ending);
                }
                break;
        }

    }

    IEnumerator SC()
    {

        isCool = false;
        yield return new WaitForSeconds(0.7f);
        isCool = true;

    }

    public void ImageMove()
    {

        if (isCool == false) return;
        ImageMove(++_index);
    }

    public void Load()
    {

        DOTween.KillAll();
        Managers.Scene.LoadScene(Define.Scene.Menu);

    }

}
