using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PAGuardState : PAState
{
    [SerializeField, MinMaxSlider(0f, 3f)]
    private Vector2 limitGurardTime;

    private float guardTime;
    private PAState _nextState;

    public override void OnStateEnter()
    {
        _enemy.ActionList[(int)StateType.Moving].Action(0);

        _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;
        guardTime = Random.Range(limitGurardTime.x, limitGurardTime.y);

        //_enemy?.OnGuardAction?.Invoke();
        _enemy.ActionList[(int)StateType.Guard].Action();
    }

    public override void OnStateLeave()
    {
        //_enemy?.OnUnGuardAction?.Invoke();
        _enemy.ActionList[(int)StateType.Unguard].Action();
    }

    public override void PlayerAction()
    {
        if(_brain.StateDuractionTime >= guardTime)
        {
            _brain.ChangeState(_nextState); // 이거 랜점말고 우선순위로 해가지고 잘할까?
        }
    }
}
