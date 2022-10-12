using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AIState
{
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
    }
}
