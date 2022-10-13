using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualNextStateCondition : AICondition
{
    public override bool IfCondition(AIState currentState, AIState nextState)
    {
        // Enemy같은 상위 스크립트에서 다음에 할 행동을 리턴해준다. 그 값을 비교
        return false;
    }
}
