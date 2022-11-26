using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using DG.Tweening;

public class StageUI : MonoBehaviour
{
    [Min(0)]
    private int _stageNum;
    private List<Sprite> _spriteList;

    [SerializeField, Range(0f, 1f)]
    private float _smallSize = 0.6f;
    [SerializeField]
    private float _time = 0.3f;

    private Image _image;
    private Button _btn;
    private HorizontalScrollSnap _scrollSnap;
    private RectTransform _rect;

    void Start()
    {
        _rect = GetComponent<RectTransform>();
        _image = GetComponentInChildren<Image>();
        _btn = GetComponentInChildren<Button>();
        _scrollSnap = GetComponentInParent<HorizontalScrollSnap>();
    }

    public void SetStageNum(int value)
    {
        _stageNum = value;

        //SetImage(_spriteList[_stageNum]);
    }

    public void SetImage(Sprite img)
    {
        _image.sprite = img;
    }

    private void Update()
    {
        //if()
        if (_scrollSnap._currentPage != _stageNum)
        {
            if (_rect.localScale != new Vector3(_smallSize, _smallSize, 1))
            {
                _rect.DOScale(new Vector3(_smallSize, _smallSize, 1), _time);
            }
        }
        else
        {
            if (_rect.localScale != Vector3.one)
            {
                _rect.DOScale(Vector3.one, _time);
            }
        }
    }
}