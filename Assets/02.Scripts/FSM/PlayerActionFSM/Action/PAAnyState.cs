using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PAAnyState : PAState
{
    [SerializeField, MinMaxSlider(0.1f, 10f)]
    private Vector2 _delayTimeOffset;

    private PAState _nextState;
    private float _delayTime;

    private void Start()
    {
        _delayTime = Random.Range(_delayTimeOffset.x, _delayTimeOffset.y);
        _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateLeave()
    {

    }

    public override void PlayerAction()
    {
        if (_enemy.IsBattle == true)
        {
            if (_brain.StateDuractionTime >= _delayTime)
            {
                _brain.ChangeState(_nextState);
                _delayTime = Random.Range(_delayTimeOffset.x, _delayTimeOffset.y);
                _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;
            }
        }
    }
}
