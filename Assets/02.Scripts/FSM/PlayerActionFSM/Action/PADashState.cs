using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PADashState : PAState
{
    [SerializeField]
    private float _dashTime = 0.5f;

    private PAState _nextState;

    private float _distance = 0;
    private bool _dir;

    public override void OnStateEnter()
    {
        _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;

        //_enemy?.OnDashAction?.Invoke();
        // 상대하고 거리가 가까우면 백대쉬
        // 멀면 앞대쉬

        _distance = Mathf.Abs(_enemy.transform.position.x - _brain.Target.transform.position.x);
        _dir = _enemy.transform.position.x < _brain.Target.transform.position.x;
        if (_distance <= 6)
        {
            _enemy.ActionList[(int)StateType.Moving].Action(_dir ? 1 : -1);

            _enemy.ActionList[(int)StateType.Dash].Action();
            _enemy.ActionList[(int)StateType.Moving].Action();
        }
        else
        {
            _enemy.ActionList[(int)StateType.Moving].Action(_dir ? -1 : 1);
            _enemy.ActionList[(int)StateType.Dash].Action();
            _enemy.ActionList[(int)StateType.Moving].Action();
        }


    }

    public override void OnStateLeave()
    {

    }

    public override void PlayerAction()
    {
        //_playerAction?.Action();

        if(_brain.StateDuractionTime >= _dashTime)
        {
            _brain.ChangeState(_nextState);
        }
    }
}
