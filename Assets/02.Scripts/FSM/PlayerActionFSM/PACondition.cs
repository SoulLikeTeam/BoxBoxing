using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PACondition : MonoBehaviour
{
    protected PABrain _brain;

    protected virtual void Awake()
    {
        _brain = GetComponentInParent<PABrain>();
    }

    public abstract bool IfCondition(PAState currState, PAState nexState);
}
