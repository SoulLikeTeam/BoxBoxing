using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ConditionAndNot
{
    public PACondition condition;
    public bool not;
}

[System.Serializable]
public class PAConditionPair
{
    public List<ConditionAndNot> condition;
    public PAState nextState;
    public int priority;
}

public abstract class PAState : MonoBehaviour
{
    protected PABrain _brain;
    protected Enemy _enemy;

    [SerializeField, System.Obsolete]
    protected PlayerAction _playerAction;

    public List<PAConditionPair> _transitionList;

    protected virtual void Awake()
    {
        _brain = GetComponentInParent<PABrain>();
        _enemy = GetComponentInParent<Enemy>();
    }

    public virtual void OnStateEnter() { }
    public virtual void OnStateLeave() { }

    public abstract void PlayerAction();
}
