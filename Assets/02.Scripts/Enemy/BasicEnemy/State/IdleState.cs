using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class IdleState : AIState
{
    private List<AIState> _stateList = new List<AIState>();
    private AIState _nextState = null;
    public AIState NextState => _nextState;

    [SerializeField, MinMaxSlider(0.1f, 100f)]
    private Vector2 _transitonOffset;

    private float _transitionTime;

    protected override void Start()
    {
        base.Start();
        _aiBrain.GetComponentsInChildren(_stateList);
        if (_stateList.Contains(this))
            _stateList.Remove(this);
    }

    public override void OnStateEnter()
    {
        if (_stateList.Count == 0)
        {
            _aiBrain.GetComponentsInChildren(_stateList);
            if (_stateList.Contains(this))
                _stateList.Remove(this);
        }

        if (_stateList.Count == 0)
            return;

        Debug.Log("Enter the Idle");

        int random = Random.Range(0, _stateList.Count);
        _nextState = _stateList[random];
        _transitionTime = Random.Range(_transitonOffset.x, _transitonOffset.y);
        Debug.Log($"Next State : {_nextState}");
    }

    public override void OnStateLeave()
    {

    }

    public override void TakeAAction()
    {
        if (_aiBrain.StateDuractionTime >= _transitionTime)
            _aiBrain.ChangeState(_nextState);
    }
}
