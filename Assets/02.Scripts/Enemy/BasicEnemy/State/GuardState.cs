using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardState : AIState
{
    private AIBrain aiBrain;
    private IdleState idleState;

    private void Awake()
    {
        aiBrain = GetComponentInParent<AIBrain>();
        idleState = aiBrain.GetComponentInChildren<IdleState>();
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }

    public override void OnStateLeave()
    {
        base.OnStateLeave();
    }

    public override void TakeAAction()
    {
        stateDurationTime += Time.deltaTime;
        Debug.Log("Attack!");
        aiBrain.ChangeState(idleState);
    }
}
