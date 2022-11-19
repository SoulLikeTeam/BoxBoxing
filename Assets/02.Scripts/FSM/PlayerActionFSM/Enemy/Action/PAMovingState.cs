using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PAMovingState : PAState
{
    [SerializeField, MinMaxSlider(0, 10)]
    private Vector2Int _moveCntOffset;
    private int _moveCnt;

    [SerializeField, MinMaxSlider(0.1f, 10f)]
    private Vector2 _moveTImeOffset;
    private float _moveTime;

    private int _moveDir = 1;

    private float _durationTime = 0;

    public override void OnStateEnter()
    {
        _moveCnt = Random.Range(_moveCntOffset.x, _moveCntOffset.y + 1);
        _moveTime = Random.Range(_moveTImeOffset.x, _moveTImeOffset.y);

        _moveDir = _brain.Enemy.transform.position.x > _brain.Target.transform.position.x ? -1 : 1;
        _durationTime = 0f;
    }

    public override void OnStateLeave()
    {
        //_playerAction?.Action(0);
        _enemy.OnIdleAction.Invoke();
    }

    public override void PlayerAction()
    {
        _enemy.OnMoveAction.Invoke(_moveDir);

        if(_brain.StateDuractionTime - _durationTime >= _moveTime)
        {
            _moveDir *= -1;
            _durationTime = _brain.StateDuractionTime;
            _moveTime = Random.Range(_moveTImeOffset.x, _moveTImeOffset.y);
            _moveCnt--;
        }

        if(_moveCnt <= 0)
        {
            _brain.ChangeState(_transitionList[Random.Range(0, _transitionList.Count)].nextState);
        }
    }
}
