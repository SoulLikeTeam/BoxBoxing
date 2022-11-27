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
    [SerializeField, Range(0f, 1f)]
    private float _time = 0.3f;

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

    public void SetScale(bool isSmall)
    {
        if(isSmall == true)
        {
            _rect.DOScale(new Vector3(_smallSize, _smallSize, 1), _time);
        }
        else
        {
            _rect.DOScale(Vector3.one, _time);
        }
    }

    private void Update()
    {
        if(_scrollSnap == null)
        {
            _scrollSnap = GetComponentInParent<HorizontalScrollSnap>();
        }

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