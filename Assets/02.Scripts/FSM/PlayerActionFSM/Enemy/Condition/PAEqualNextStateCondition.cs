using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAEqualNextStateCondition : PACondition
{
    public override bool IfCondition(PAState currState, PAState nexState)
    {
        return _brain.GetNextState() == nexState;
    }
}
