using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualNextStateCondition : AICondition
{
    public override bool IfCondition(AIState currentState, AIState nextState)
    {
        // Enemy���� ���� ��ũ��Ʈ���� ������ �� �ൿ�� �������ش�. �� ���� ��
        return false;
    }
}
