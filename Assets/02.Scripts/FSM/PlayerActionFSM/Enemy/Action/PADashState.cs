using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PADashState : PAState
{
    public override void OnStateEnter()
    {

    }

    public override void OnStateLeave()
    {

    }

    public override void PlayerAction()
    {
        //_playerAction?.Action();
        _enemy?.OnDashAction?.Invoke();

        //_brain.ChangeState(_transitionList[Random.Range(0, _transitionList.Count)].nextState);
    }
}
