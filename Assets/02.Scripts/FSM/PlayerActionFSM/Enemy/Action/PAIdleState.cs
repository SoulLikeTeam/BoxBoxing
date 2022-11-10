using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PAIdleState : PAState
{
    [SerializeField, MinMaxSlider(0f, 1f)]
    private Vector2 delayTime;

    private float time = 0f;

    public override void OnStateEnter()
    {
        time = Random.Range(delayTime.x, delayTime.y);
    }

    public override void OnStateLeave()
    {
        
    }

    public override void PlayerAction()
    {
        _playerAction?.Action();

        if(_brain.StateDuractionTime >= time)
        {
            _brain.ChangeState(_transitionList[Random.Range(0, _transitionList.Count)].nextState);
        }
    }
}
