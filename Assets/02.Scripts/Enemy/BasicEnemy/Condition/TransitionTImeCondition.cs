using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTimeCondition : AICondition
{
    private AIBrain _aiBrain;

    private void Start()
    {
        _aiBrain = GetComponent<AIBrain>();
    }

    public override bool IfCondition(AIState currentState, AIState nextState)
    {
        return false;
    }
}
