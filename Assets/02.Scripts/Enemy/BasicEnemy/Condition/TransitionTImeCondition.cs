using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTImeCondition : AICondition
{
    [SerializeField]
    private float _transitionTime = 5f;

    public override bool IfCondition(AIState currentState, AIState nextState)
    {
        if (currentState.StateDurationTime >= _transitionTime)
        {
            return true;
        }
        else return false;
    }
}
