using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PARandomCondition : PACondition
{
    [SerializeField, Range(0f, 100f)]
    private int random;
    public override bool IfCondition(PAState currState, PAState nexState)
    {
        return Random.Range(1, 101) < random;
    }
}
