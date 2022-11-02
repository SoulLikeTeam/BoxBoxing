using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PAConditionPair
{
    public List<PACondition> condition;
    public PAState nextState;
    public int priority;
}

public abstract class PAState : MonoBehaviour
{
    protected PABrain _brain;

    [SerializeField]
    protected PlayerAction _playerAction;

    public List<PAConditionPair> _transitionList;

    protected virtual void Awake()
    {
        _brain = GetComponentInParent<PABrain>();
    }

    public virtual void OnStateEnter() { }
    public virtual void OnStateLeave() { }

    public abstract void PlayerAction();
}
