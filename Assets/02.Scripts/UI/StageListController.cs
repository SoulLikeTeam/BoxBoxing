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

    [SerializeField]
    private Transform _parent;

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
    }

    public void CreateUI()
    {
        for (int i = 0; i < _stageCnt; i++)
        {
            GameObject go = Managers.Resource.Instantiate("UI/Stage", this.transform);
            StageUI stageUI = go.GetComponent<StageUI>();
            stageUI.SetStageNum(i);

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

        _uiSizeX = _stageList[0].GetComponent<RectTransform>().sizeDelta.x;
        _targetPos = Vector2.zero;
        float offset = _sortingIndex == -1 ? _offset : -1 * (_uiSizeX + _spacing) * _sortingIndex + _offset;
        _targetPos.x += offset;
    }

    public IEnumerator StageUIMove(Action action = null)
    {
        // 인덱스가 -1이랑 0일때 이상한 곳으로 감
        Vector3 targetScreenPos = _mainCam.WorldToScreenPoint(_targetPos);
        int cnt = 0;
        while (_rect.anchoredPosition != _targetPos)
        {
            _rect.transform.position = Vector2.MoveTowards(_rect.transform.position, targetScreenPos, _moveSpeed);
            cnt++;

            if (cnt >= 10000)
            {
                Debug.Log("무한루프");
                break;
            }
            yield return null;
        }

        action?.Invoke();
    }

    public void StageUIEffect()
    {
        for(int i = 0; i < _stageList.Count; i++)
        {
            if(i == _sortingIndex)
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
