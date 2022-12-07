using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PANotCondition : PACondition
{
    public override bool IfCondition(PAState currState, PAState nexState)
    {
        return false;
    }
}
