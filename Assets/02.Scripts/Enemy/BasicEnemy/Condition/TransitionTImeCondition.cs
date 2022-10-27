using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTimeCondition : AICondition
{
    private AIBrain _aiBrain;

    [SerializeField]
    private float _transitionTime;

    private void Start()
    {
        _aiBrain = GetComponentInParent<AIBrain>();
    }

    public override bool IfCondition(AIState currentState, AIState nextState)
    {
        return _transitionTime >= _aiBrain.StateDuractionTime;
    }
}
