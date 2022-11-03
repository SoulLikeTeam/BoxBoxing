using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;

public class GuardState : AIState
{
    private Animator animator;
    private PlayerState playerState;

    private IdleState idleState;

    [SerializeField, MinMaxSlider(0.1f, 100f)]
    private Vector2 _guardOffset;

    private float _guardTime;

    protected override void Awake()
    {
        base.Awake();
        idleState = _aiBrain.GetComponentInChildren<IdleState>();
        animator = transform.parent.parent.Find("VisualSprite").GetComponent<Animator>();
        playerState = animator.GetComponent<PlayerState>();
    }

    public override void OnStateEnter()
    {
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
