using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AIState
{
    private IdleState idleState;

    // Debug
    private float _transitionTime = 3f;

    protected override void Start()
    {
        base.Start();
        idleState = _aiBrain.GetComponentInChildren<IdleState>();
    }

    public override void OnStateEnter()
    {
        Debug.Log("Enter the Attack");
    }

    public override void OnStateLeave()
    {

    }

    public override void TakeAAction()
    {
        if(_aiBrain.StateDuractionTime >= _transitionTime)
            _aiBrain.ChangeState(idleState);
    }
}
