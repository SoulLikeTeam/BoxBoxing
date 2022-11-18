using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAPunchState : PAState
{
    [SerializeField]
    private float punchTime = 0.3f;

    private PAState _nextState;

    public override void OnStateEnter()
    {
        _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;

        _enemy?.OnPunchAction?.Invoke();
    }

    public override void OnStateLeave()
    {
        
    }

    public override void PlayerAction()
    {
        //_playerAction?.Action();

        if(_brain.StateDuractionTime >= punchTime)
        {
            _brain.ChangeState(_nextState);
        }
    }
}
