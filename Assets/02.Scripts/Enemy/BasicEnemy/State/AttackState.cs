using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AIState
{
    private IdleState idleState;

    // Debug
    private float _transitionTime = 3f;

    protected override void Awake()
    {
        base.Awake();
        idleState = _aiBrain.GetComponentInChildren<IdleState>();
    }

    public override void OnStateEnter()
    {
        //animator.SetTrigger(punchHash);
        //animator.SetFloat(punchCountHash, Random.Range(0, 2));
        //state.SetState(Define.PlayerStates.Punch);
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
