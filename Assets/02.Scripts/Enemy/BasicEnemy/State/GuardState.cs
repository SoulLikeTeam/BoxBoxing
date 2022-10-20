using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GuardState : AIState
{
    private IdleState idleState;

    [SerializeField, MinMaxSlider(0.1f, 100f)]
    private Vector2 _guardOffset;

    private float _guardTime;

    protected override void Start()
    {
        base.Start();
        idleState = _aiBrain.GetComponentInChildren<IdleState>();
    }

    public override void OnStateEnter()
    {
        Debug.Log("Enter the Guard");

        _guardTime = Random.Range(_guardOffset.x, _guardOffset.y);
    }

    public override void OnStateLeave()
    {

    }

    public override void TakeAAction()
    {
        if(_aiBrain.StateDuractionTime >= _guardTime)
        {
            _aiBrain.ChangeState(idleState);
        }
    }
}
