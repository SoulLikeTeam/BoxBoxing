using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTImeCondition : AICondition
{
    // 디버그 용
    [SerializeField]
    private float _transitionTime = 5f; // 이 시간 나중에 Enemy 스크립트 같은 상위 스크리븥로 옴기기. 거기서 랜덤괎 주고 가져오기

    public override bool IfCondition(AIState currentState, AIState nextState)
    {
        if (currentState.StateDurationTime >= _transitionTime)
        {
            return true;
        }
        else return false;
    }
}
