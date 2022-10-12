using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConditionPair
{
    public List<AICondition> conditionList;
    public AIState nextState;
    public int priority;
}

public abstract class AIState : MonoBehaviour
{
    protected float stateDurationTime = 0f;

    public List<ConditionPair> _transitionList;

    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateLeave()
    {

    }

    public abstract void TakeAAction();
}
