using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PASitState : PAState
{
    [SerializeField, MinMaxSlider(0.1f, 10f)]
    private Vector2 _sitTimeOffset;

    private float _sitTime;
    private PAState _nextState;

    public override void OnStateEnter()
    {
        _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;
        _sitTime = Random.Range(_sitTimeOffset.x, _sitTimeOffset.y);

        _enemy?.OnSitAction?.Invoke();
    }

    public override void OnStateLeave()
    {
        _enemy?.OnUnSitAction?.Invoke();
    }

    public override void PlayerAction()
    {
        if(_brain.StateDuractionTime >= _sitTime)
        {
            _brain.ChangeState(_nextState);
        }
    }
}
