using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PATimeCondition : PACondition
{
    [SerializeField, Range(0.1f, 10f)]
    private float _transitionTime = 2f;

    public override bool IfCondition(PAState currState, PAState nexState)
    {
        return _brain.StateDuractionTime >= _transitionTime;
    }
}
