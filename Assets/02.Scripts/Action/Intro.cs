using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Intro : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {

        GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() =>
        {


            Managers.Scene.LoadScene(Define.Scene.Story);

        });


    }
}
