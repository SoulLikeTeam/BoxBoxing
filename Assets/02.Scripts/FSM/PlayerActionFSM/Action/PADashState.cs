using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PADashState : PAState
{
    [SerializeField]
    private float _dashTime = 0.5f;

    private PAState _nextState;

    public override void OnStateEnter()
    {
        _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;

        //_enemy?.OnDashAction?.Invoke();
        _enemy.ActionList[(int)StateType.Dash].Action();
        _enemy.ActionList[(int)StateType.Moving].Action();


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
