using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageListController : MonoBehaviour
{
    [SerializeField, Min(0)]
    private int _stageCnt = 5;

    [SerializeField]
    private Transform _parent;

    private List<GameObject> _stageList = new List<GameObject>();

    private RectTransform _rect;
    private Camera _mainCam;
    private HorizontalLayoutGroup _hLayoutGroup;

    private Vector2 _targetPos = Vector2.zero;

    [SerializeField]
    private float _moveSpeed = 5f;

    private AllStageInfo _stageInfo;

    private float _uiSizeX = 500;
    private float _spacing = 100;
    private float _offset = 40;
    private void Start()
    {
        _mainCam = Camera.main;

        _rect = GetComponent<RectTransform>();
        _hLayoutGroup = GetComponent<HorizontalLayoutGroup>();
        _spacing = _hLayoutGroup.spacing;

        _stageInfo = Managers.Save.LoadJsonFile<AllStageInfo>();

        float offset = _stageInfo.stageIdx == -1 ? _offset : -1 * (_uiSizeX + _spacing) + _offset;
        _targetPos.x += offset;

        //GameObject go = Managers.Resource.Instantiate("UI/Stage");
        //stageList.Add(go);

        StageUIMove();
    }

    private void StageUIMove()
    {
        while (_rect.transform.position != _mainCam.WorldToScreenPoint(_targetPos))
        {
            _rect.transform.position = Vector2.MoveTowards(_rect.transform.position, _mainCam.WorldToScreenPoint(_targetPos), _moveSpeed);
        }
    }
}
