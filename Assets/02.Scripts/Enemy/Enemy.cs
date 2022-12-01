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
    private float _guardDistance = 3f;

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
        // ���� Ȯ�� �м�
        // ���� �� �� �ൿ �� �ϳ� �׳� ���� ���ϱ�
        // ���� �� �� �ൿ �� �ϳ� 1. ���� �ø��� 2. �ڷ� �뽬�ϱ�

        if (Mathf.Abs(_brain.Target.transform.position.x - transform.position.x) > _guardDistance) return;

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

            // TODO: ���� �±�
            // �׳� �����ϸ� �ǳ�?
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
            //    _brain.ChangeState(_guardState); // ����
            //}
            //else
            //{
            //    Debug.Log("Dash");
            //    _brain.ChangeState(_dashState); // �� �뽬
            //}

            Debug.Log("Guard");
            _brain.ChangeState(_guardState); // �뽬 ������ �̻��ϱ⿡ �ϴ� ���常 ��
        }

    }
}
