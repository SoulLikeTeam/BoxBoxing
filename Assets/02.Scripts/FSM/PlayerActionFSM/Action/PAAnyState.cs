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

    private float _timer = 0f;

    private void Start()
    {
        _timer = 0f;

        _delayTime = Random.Range(_delayTimeOffset.x, _delayTimeOffset.y);
        _nextState = _transitionList[Random.Range(0, 3)].nextState;
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
            _timer += Time.deltaTime;

            if (_timer >= _delayTime)
            {
                _brain.ChangeState(_nextState);
                _delayTime = Random.Range(_delayTimeOffset.x, _delayTimeOffset.y);
                _nextState = _transitionList[Random.Range(0, 3)].nextState;
                _timer = 0f;
            }
        }
    }
}
