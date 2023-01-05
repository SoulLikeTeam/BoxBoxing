using DG.Tweening;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{

    [SerializeField] private GameObject storyObj;
    [SerializeField] private bool isStart = true;

    private void Start()
    {

        if (isStart)
        {

            Sequence sequence = DOTween.Sequence();

            sequence
                .AppendInterval(1.3f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 0, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 2, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 2, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 3, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 3, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 4, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 4, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 5, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 5, 0), 0.5f))
                .AppendInterval(1.9f)
                .AppendCallback(() => Managers.Scene.LoadScene(Define.Scene.Menu));

        }
        else
        {

            Sequence sequence = DOTween.Sequence();

            sequence
                .AppendInterval(1.3f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 0, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 2, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 2, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 3, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 3, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 4, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 4, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(0, 1080 * 5, 0), 0.5f))
                .AppendInterval(1.9f)
                .Append(storyObj.transform.DOMove(storyObj.transform.position + new Vector3(-1920, 1080 * 5, 0), 0.5f))
                .AppendInterval(1.9f)
                .AppendCallback(() => Managers.Scene.LoadScene(Define.Scene.Ending));

        }

    }

}
