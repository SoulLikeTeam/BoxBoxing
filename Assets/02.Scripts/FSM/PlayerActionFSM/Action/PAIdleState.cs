using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PAIdleState : PAState
{
    [SerializeField]
    private float _idleTime = 0.1f;
    [SerializeField]
    private PAState _attackState;

    private PAState _nextState;

    public override void OnStateEnter()
    {
        do
        {
            _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;
        } while (_nextState == null);
    }

    public override void OnStateLeave()
    {
        
    }

    public override void PlayerAction()
    {
        //_playerAction?.Action();
        //_enemy.OnIdleAction?.Invoke();
        _enemy.ActionList[(int)StateType.Moving].Action(0);

        if (_enemy.IsBattle == true)
        {
            if (_brain.StateDuractionTime >= _idleTime)
            {
                _brain.ChangeState(_nextState);
            }
        }
    }
}
