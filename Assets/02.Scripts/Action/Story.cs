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

    private int _index = 0;

    //private void Start()
    //{

    //    if (isStart)
    //    {

    //        Sequence sequence = DOTween.Sequence();

    //        sequence
    //            .AppendInterval(1.3f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 0, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 2, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 2, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 3, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 3, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 4, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 4, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 5, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 5, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .AppendCallback(() => Managers.Scene.LoadScene(Define.Scene.Menu));

    //    }
    //    else
    //    {

    //        Sequence sequence = DOTween.Sequence();

    //        sequence
    //            .AppendInterval(1.3f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 0, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 2, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 2, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 3, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 3, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 4, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 4, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 5, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 5, 0), 0.5f))
    //            .AppendInterval(1.9f)
    //            .Append(fadeImage.DOFade(1, 0.7f))
    //            .AppendInterval(1.9f)
    //            .AppendCallback(() => Managers.Scene.LoadScene(Define.Scene.Ending));

    //    }

    //}

    public void ImageMove(int index)
    {
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
        //switch (index)
        //{
        //    case 0:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(0, 0, 0), 0.5f);
        //        break;
        //    case 1:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(-1920, 0, 0), 0.5f);
        //        break;
        //    case 2:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(0, 1080, 0), 0.5f);
        //        break;
        //    case 3:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(-1920, 0, 0), 0.5f);
        //        break;
        //    case 4:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(0, 1080 * 2, 0), 0.5f);
        //        break;
        //    case 5:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(-1920, 1080 * 2, 0), 0.5f);
        //        break;
        //    case 6:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(0, 1080 * 3, 0), 0.5f);
        //        break;
        //    case 7:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(-1920, 1080 * 3, 0), 0.5f);
        //        break;
        //    case 8:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(0, 1080 * 4, 0), 0.5f);
        //        break;
        //    case 9:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(-1920, 1080 * 4, 0), 0.5f);
        //        break;
        //    case 10:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(0, 1080 * 5, 0), 0.5f);
        //        break;
        //    case 11:
        //        storyObj.GetComponent<RectTransform>().DOMove(new Vector3(-1920, 1080 * 5, 0), 0.5f);
        //        break;
        //    default:
        //        if (isStart)
        //        {
        //            Managers.Scene.LoadScene(Define.Scene.Menu);
        //        }
        //        else
        //        {
        //            Managers.Scene.LoadScene(Define.Scene.Ending);
        //        }
        //        break;
        //}
    }

    public void ImageMove()
    {
        ImageMove(++_index);
    }

    public void Load()
    {

        DOTween.KillAll();
        Managers.Scene.LoadScene(Define.Scene.Menu);

    }

}
