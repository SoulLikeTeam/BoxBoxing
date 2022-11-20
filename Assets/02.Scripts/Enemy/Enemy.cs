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

    private void Start()
    {
        _brain = transform.Find("AI").GetComponent<PABrain>();
    }

    public void Guard()
    {
        // ���� Ȯ�� �м�
        // ���� �� �� �ൿ �� �ϳ� 1. �� �ʰ� ���� �ø��� 2. �׳� ���� ���ϱ�
        // ���� �� �� �ൿ �� �ϳ� 1. ���� �ø��� 2. �ڷ� �뽬�ϱ�

        StartCoroutine(GuardCoroutine(0f));
    }

    private IEnumerator GuardCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        _brain.ChangeState(_guardState);
    }
}
