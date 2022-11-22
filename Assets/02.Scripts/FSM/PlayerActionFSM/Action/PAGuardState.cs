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

        _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;
        guardTime = Random.Range(limitGurardTime.x, limitGurardTime.y);

        //_enemy?.OnGuardAction?.Invoke();
        bool dir = _enemy.transform.position.x < _brain.Target.transform.position.x;
        _enemy.ActionList[(int)StateType.Moving].Action(dir ? 1 : -1); // 플레이어 바라보게 방향 전환 후
        _enemy.ActionList[(int)StateType.Moving].Action(0); // 정지

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
