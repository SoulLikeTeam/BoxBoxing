using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PAGuardState : PAState
{
    [SerializeField, MinMaxSlider(0f, 3f)]
    private Vector2 limitGurardTime;

    private float guardTime;

    public override void OnStateEnter()
    {
        guardTime = Random.Range(limitGurardTime.x, limitGurardTime.y);
    }

    public override void OnStateLeave()
    {

    }

    public override void PlayerAction()
    {
        _enemy?.OnGuardAction?.Invoke();

        if(_brain.StateDuractionTime >= guardTime)
        {
            _enemy?.OnUnGuardAction?.Invoke();
            _brain.ChangeState(_transitionList[Random.Range(0, _transitionList.Count)].nextState); // 이거 랜점말고 우선순위로 해가지고 잘할까?
        }
    }
}
