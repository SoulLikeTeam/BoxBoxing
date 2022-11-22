using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PAEscapeState : PAState
{
    [SerializeField, MinMaxSlider(0, 10), System.Obsolete]
    private Vector2Int _moveCntOffset;
    [System.Obsolete]
    private int _moveCnt;

    [SerializeField, MinMaxSlider(0.1f, 10f)]
    private Vector2 _moveTimeOffset;
    private float _moveTime;
    private int _moveDir = 1;
    [System.Obsolete]
    private float _durationTime = 0;

    private PAState _nextState;

    public override void OnStateEnter()
    {
        //_nextState = _transitionList[Random.Range(0, 4)].nextState; // 앞의 3개의 상태로만 랜덤
        do
        {
            _nextState = _transitionList[Random.Range(0, 5)].nextState;
        } while (_nextState == _brain.GetBeforeState());

        _moveTime = Random.Range(_moveTimeOffset.x, _moveTimeOffset.y);
        _moveDir = _enemy.transform.position.x < _brain.Target.transform.position.x ? -1 : 1;

        //_moveCnt = Random.Range(_moveCntOffset.x, _moveCntOffset.y + 1);
        //_moveTime = Random.Range(_moveTimeOffset.x, _moveTimeOffset.y);

        //_moveDir = _brain.Enemy.transform.position.x > _brain.Target.transform.position.x ? -1 : 1;
        //_durationTime = 0f;
    }

    public override void OnStateLeave()
    {
        //_playerAction?.Action(0);
        //_enemy.OnIdleAction.Invoke();
        //_enemy.ActionList[(int)StateType.Moving].Action(0);
    }

    public override void PlayerAction()
    {
        //_enemy.OnMoveAction.Invoke(_moveDir);
        //_enemy.ActionList[(int)StateType.Moving].Action(_moveDir);

        //if(_brain.StateDuractionTime - _durationTime >= _moveTime)
        //{
        //    _moveDir *= -1;
        //    _durationTime = _brain.StateDuractionTime;
        //    _moveTime = Random.Range(_moveTimeOffset.x, _moveTimeOffset.y);
        //    _moveCnt--;
        //}

        //if(_moveCnt <= 0)
        //{
        //    _brain.ChangeState(_nextState);
        //}

        _enemy.ActionList[(int)StateType.Moving].Action(_moveDir);

        if(_brain.StateDuractionTime >= _moveTime)
        {
            _brain.ChangeState(_nextState);
        }
    }
}
