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
        do
        {
        _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;
        } while(_nextState == null);
        _sitTime = Random.Range(_sitTimeOffset.x, _sitTimeOffset.y);

        //_enemy?.OnSitAction?.Invoke();
        _enemy?.ActionList[(int)StateType.Sit].Action();
    }

    public override void OnStateLeave()
    {
        //_enemy?.OnUnSitAction?.Invoke();
        _enemy?.ActionList[(int)StateType.Unsit].Action();
    }

    public override void PlayerAction()
    {
        if(_brain.StateDuractionTime >= _sitTime)
        {
            _brain.ChangeState(_nextState);
        }
    }
}
