using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualNextStateCondition : AICondition
{
    public override bool IfCondition(AIState currentState, AIState nextState)
    {
        IdleState idleState = currentState as IdleState;
        return idleState.NextState == nextState;
    }
}
