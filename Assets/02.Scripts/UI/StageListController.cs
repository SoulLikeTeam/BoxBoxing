using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageListController : MonoBehaviour
{
    [SerializeField, Min(0)]
    private int _stageCnt = 5;

    private List<StageUI> _stageList = new List<StageUI>();

    private RectTransform _rect;
    private Camera _mainCam;
    private HorizontalLayoutGroup _hLayoutGroup;

    private Vector2 _targetPos = Vector2.zero;

    [SerializeField]
    private float _moveSpeed = 5f;

    private AllStageInfo _stageInfo;

    private float _uiSizeX = 300;
    private float _spacing = 100;
    private float _offset = 40;

    private int _sortingIndex = -1;

    public void Init()
    {
        _mainCam = Camera.main;

        _rect = GetComponent<RectTransform>();
        _hLayoutGroup = GetComponent<HorizontalLayoutGroup>();
        _spacing = _hLayoutGroup.spacing;

        _stageInfo = Managers.Save.LoadJsonFile<AllStageInfo>();
        _sortingIndex = _stageInfo.stageIdx;
        if (_stageInfo.stageInfo.Count <= 0)
        {
            for (int i = 0; i < _stageCnt; i++)
            {
                StageInfo info = new StageInfo();
                info.isClear = false;
                info.clearTime = -1f;
                _stageInfo.stageInfo.Add(info);
            }
            Managers.Save.SaveJson(_stageInfo);
        }
    }

    public void CreateUI()
    {
        for (int i = 0; i < _stageCnt; i++)
        {
            GameObject go = Managers.Resource.Instantiate("UI/Stage", this.transform);
            StageUI stageUI = go.GetComponent<StageUI>();
            stageUI.SetStageNum(i);
            stageUI.SetInfo(_stageInfo.stageInfo[i]);

            if (i == _sortingIndex)
            {
                stageUI.SetBtnEvent(() =>
                {
                    _stageInfo.stageIdx = stageUI.GetStageNum();
                    Managers.Save.SaveJson<AllStageInfo>(_stageInfo);
                    Debug.Log(_stageInfo.stageIdx);
                    Managers.Scene.LoadScene(Define.Scene.Game);
                });
            }

            _stageList.Add(stageUI);
        }
    }

    public IEnumerator StageUIMove(Action action = null)
    {
        _uiSizeX = _stageList[0].GetComponent<RectTransform>().sizeDelta.x;
        _targetPos = Vector2.zero;
        float offset = _sortingIndex <= 0 ? -1 * _offset : -1 * (_uiSizeX + _spacing) * _sortingIndex + _offset;
        _targetPos.x += offset - (70f + (_sortingIndex * 16));

        Vector3 targetScreenPos = _mainCam.WorldToScreenPoint(_targetPos);
        while (_rect.anchoredPosition != _targetPos)
        {
            _rect.anchoredPosition = Vector2.MoveTowards(_rect.anchoredPosition, _targetPos, _moveSpeed);
            yield return null;
        }

        action?.Invoke();
    }

    public void StageUIEffect()
    {
        int index = Mathf.Max(0, _sortingIndex);
        for(int i = 0; i < _stageList.Count; i++)
        {
            if(i == index)
            {
                _stageList[i].SetScale(1.4f);
            }
            else
            {
                _stageList[i].SetAlpha(0.6f);
            }
        }
    }

    public void Clear()
    {
        foreach(StageUI stage in _stageList)
        {
            stage.Reset();
            Poolable pool = stage.GetComponent<Poolable>();
            Managers.Pool.Push(pool);
        }
    }
}
