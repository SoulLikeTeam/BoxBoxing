using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using NaughtyAttributes;
using DG.Tweening;

public class StageUI : MonoBehaviour
{
    [Min(0)]
    private int _stageNum;
    private List<Sprite> _spriteList;

    [SerializeField, Range(0f, 1f) ,ShowIf("IsReverseFalse")]
    private float _smallSize = 0.6f;
    [SerializeField, Range(1f, 2f), ShowIf("IsReverseTrue")]
    private float _bigSize = 1.2f;
    [SerializeField, Range(0f, 1f)]
    private float _time = 0.3f;
    [SerializeField, Range(0f, 1f)]
    private float _alpha = 0.6f;

    [SerializeField]
    private bool isBig = false;

    public bool IsReverseTrue => (isBig == true);
    public bool IsReverseFalse => (isBig == false);

    private Image _stageImage;
    private Image _clearIamge;
    private Button _btn;
    private HorizontalScrollSnap _scrollSnap;
    private RectTransform _rect;
    private Text _clearTimeText;

    private float _clearTime = 0f;
    private bool _isClear = false;

    void Start()
    {
        TryGetComponent<RectTransform>(out _rect);
        _stageImage = transform.Find("Stage Image").GetComponent<Image>();
        _clearIamge = transform.Find("Clear Image").GetComponent<Image>();
        _clearTimeText = transform.Find("Clear Time Text").GetComponent<Text>();
        _btn = GetComponentInChildren<Button>();
        _scrollSnap = GetComponentInParent<HorizontalScrollSnap>();
    }

    public void SetStageNum(int value)
    {
        _stageNum = value;

        //SetImage(_spriteList[_stageNum]);
    }

    public int GetStageNum()
    {
        return _stageNum;
    }

    public void SetImage(Sprite img)
    {
        _stageImage.sprite = img;
    }

    public void SetInfo(StageInfo info)
    {
        _clearTime = info.clearTime;
        _isClear = info.isClear;

        if(_isClear == true)
        {
            // 클리어 표식 표시하기
            _clearIamge.gameObject.SetActive(true);
            // 클리어 타임 표시하기
            _clearTimeText.text = _clearTime.ToString();
            _clearTimeText.gameObject.SetActive(true);
        }
        else
        {
            _clearIamge.gameObject.SetActive(false);
            _clearTimeText.gameObject.SetActive(false);
        }
    }

    public void SetScale(bool value)
    {
        if(value == true)
        {
            _rect.DOScale(new Vector3(isBig ? 1 : _smallSize, isBig ? 1 : _smallSize, 1), _time);
        }
        else
        {
            _rect.DOScale(new Vector3(isBig ? _bigSize : 1, isBig ? _bigSize : 1, 1), _time);
        }
    }

    public void SetAlpha(float value)
    {
        value = Mathf.Clamp(value, 0f, 1f);

        Color color = _stageImage.color;
        color.a = value;
        _stageImage.color = color;
    }

    private void Update()
    {
        if(_scrollSnap == null)
        {
            _scrollSnap = GetComponentInParent<HorizontalScrollSnap>();
        }

        if (_scrollSnap._currentPage != _stageNum)
        {
            if (_rect.localScale != (isBig ? Vector3.one : new Vector3(_smallSize, _smallSize, 1)))
            {
                SetScale(true);
            }

            if(_stageImage.color.a != _alpha)
            {
                SetAlpha(_alpha);
            }
        }
        else
        {
            if (_rect.localScale != (isBig ? new Vector3(_bigSize, _bigSize, 1) : Vector3.one))
            {
                SetScale(false);
            }

            if (_stageImage.color.a != 1)
            {
                SetAlpha(1);
            }
        }
    }
}