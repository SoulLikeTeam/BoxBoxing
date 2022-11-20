using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAChaseState : PAState
{
    RaycastHit2D frontRay;
    RaycastHit2D backRay;

    [SerializeField]
    private float _distance = 3f;

    private float _distanceOffset = 2f;

    private float _targetDistance;
    private float _moveDirection = 0;

    private PAState _nextState;

    public override void OnStateEnter()
    {
        _nextState = _transitionList[Random.Range(0, 4)].nextState;
    }

    public override void OnStateLeave()
    {
        //_playerAction?.Action(0);
        //_enemy?.OnIdleAction?.Invoke();
        _enemy.ActionList[(int)StateType.Moving].Action(0);
    }

    public override void PlayerAction()
    {
        //_targetDistance = Vector2.Distance(transform.position, _brain.Target.transform.position);

        //if(_targetDistance < Mathf.Abs(_distance - _distanceOffset))
        //{
        //    // 적 에게 가까이 가기
        //    if(transform.position.x < _brain.Target.transform.position.x)
        //    {
        //        _moveDirection = -1;
        //    }
        //    else
        //    {
        //        _moveDirection = 1;
        //    }
        //}
        //else if(_targetDistance > Mathf.Abs(_distance + _distanceOffset))
        //{
        //    // 적에게서 멀어지기
        //    if (transform.position.x < _brain.Target.transform.position.x)
        //    {
        //        _moveDirection = 1;
        //    }
        //    else
        //    {
        //        _moveDirection = -1;
        //    }
        //}

        _moveDirection = _brain.Target.transform.position.x < _brain.Enemy.transform.position.x ? -1 : 1;

        //_playerAction?.Action(_moveDirection);
        //_enemy?.OnMoveAction?.Invoke(_moveDirection);
        _enemy?.ActionList[(int)StateType.Moving].Action(_moveDirection);
    }
}
