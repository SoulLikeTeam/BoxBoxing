using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PAChaseState : PAState
{
    [SerializeField, MinMaxSlider(0.1f, 10f)]
    private Vector2 _chaseTimeOffset;

    private float _chaseTime;

    private float _moveDirection = 0;

    private PAState _nextState;

    public override void OnStateEnter()
    {
        _nextState = _transitionList[Random.Range(0, 4)].nextState;
        _chaseTime = Random.Range(_chaseTimeOffset.x, _chaseTimeOffset.y);
    }

    public override void OnStateLeave()
    {
        //_playerAction?.Action(0);
        //_enemy?.OnIdleAction?.Invoke();
        //_enemy.ActionList[(int)StateType.Moving].Action(0);
    }

    public override void PlayerAction()
    {
        _moveDirection = _brain.Target.transform.position.x < _brain.Enemy.transform.position.x ? -1 : 1;

        //_playerAction?.Action(_moveDirection);
        //_enemy?.OnMoveAction?.Invoke(_moveDirection);
        _enemy?.ActionList[(int)StateType.Moving].Action(_moveDirection);

        if(_brain.StateDuractionTime >= _chaseTime)
        {
            _brain.ChangeState(_nextState);
        }
    }
}
