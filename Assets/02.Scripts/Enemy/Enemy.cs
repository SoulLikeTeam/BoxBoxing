using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
using static Define;

public enum AILevel
{
    Easy,
    Normal,
    Hard,
    Custom
}

public enum StateType
{
    Moving,
    Dash,
    Punch,
    Sit,
    Unsit,
    Guard,
    Unguard
}

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private AILevel aiLevel;

    [SerializeField, Foldout("Custom Level"), Range(0f, 100f)]
    private float _customProbability;

    [SerializeField, Foldout("Not Custom Level"), Range(0f, 100f)] private float _easyProbability;
    [SerializeField, Foldout("Not Custom Level"), Range(0f, 100f)] private float _normalProbability;
    [SerializeField, Foldout("Not Custom Level"), Range(0f, 100f)] private float _hardProbability;

    //#region State Action Event
    //[Foldout("Events")] public UnityEvent<float> OnMoveAction;
    //[Foldout("Events")] public UnityEvent OnDashAction;
    //[Foldout("Events")] public UnityEvent OnPunchAction;
    //[Foldout("Events")] public UnityEvent OnSitAction;
    //[Foldout("Events")] public UnityEvent OnUnSitAction;
    //[Foldout("Events")] public UnityEvent OnIdleAction;
    //[Foldout("Events")] public UnityEvent OnGuardAction;
    //[Foldout("Events")] public UnityEvent OnUnGuardAction;
    //#endregion

    [SerializeField, Tooltip("Moving, Dash, Punch, Sit, Unsit, Guard, Unguard")]
    private List<PlayerAction> _actionList;
    public List<PlayerAction> ActionList => _actionList;

    private PABrain _brain;
    [SerializeField]
    private PAState _guardState;
    [SerializeField]
    private PAState _dashState;

    private bool isBattle = false;
    public bool IsBattle { get => isBattle; set => isBattle = value; }

    private void Start()
    {
        _brain = transform.Find("AI").GetComponent<PABrain>();
    }

    public void Guard()
    {
        // 성공 확률 분석
        // 성공 시 두 행동 중 하나 그냥 반응 못하기
        // 실패 시 두 행동 주 하나 1. 가드 올리기 2. 뒤로 대쉬하기

        float random = Random.Range(0f, 100f);
        float probability = aiLevel switch
        {
            AILevel.Easy => _easyProbability,
            AILevel.Normal => _normalProbability,
            AILevel.Hard => _hardProbability,
            AILevel.Custom => _customProbability,
            _ => _customProbability,
        };

        if (random < probability)
        {
            // Success

            // TODO: 공격 맞기
            // 그냥 리턴하면 되나?
            Debug.Log("Success");
            return;
        }
        else
        {
            // Fail
            Debug.Log("Fail");
            //float rnd = Random.value;
            //if(rnd <= 0.5f)
            //{
            //    Debug.Log("Guard");
            //    _brain.ChangeState(_guardState); // 가드
            //}
            //else
            //{
            //    Debug.Log("Dash");
            //    _brain.ChangeState(_dashState); // 백 대쉬
            //}

            Debug.Log("Guard");
            _brain.ChangeState(_guardState); // 대쉬 구현이 이상하기에 일달 가드만 함
        }

    }
}
