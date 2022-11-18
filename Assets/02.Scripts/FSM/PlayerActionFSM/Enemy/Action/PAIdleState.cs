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
        _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;
    }

    public override void OnStateLeave()
    {
        
    }

    public override void PlayerAction()
    {
        //_playerAction?.Action();
        _enemy.OnIdleAction?.Invoke();

        if(_brain.GetBeforeState() == _attackState)
        {
            _brain.ChangeState(_nextState);
        }
    }
}
