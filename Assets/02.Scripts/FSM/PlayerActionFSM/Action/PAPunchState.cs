using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAPunchState : PAState
{
    [SerializeField]
    private float punchTime = 0.3f;

    private PAState _nextState;

    public override void OnStateEnter()
    {
        _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;

        //_enemy?.OnPunchAction?.Invoke();
        // 적 바라보기

        bool dir = _enemy.transform.position.x < _brain.Target.transform.position.x;
        _enemy.ActionList[(int)StateType.Moving].Action(dir ? 1 : -1);
        _enemy.ActionList[(int)StateType.Punch].Action();
        Debug.Log("Punch!");

        //여기에 공격 넣기

        GameObject.Find("Player").GetComponentInChildren<PlayerManagement>().Hit();

    }

    public override void OnStateLeave()
    {
        
    }

    public override void PlayerAction()
    {
        //_playerAction?.Action();

        if(_brain.StateDuractionTime >= punchTime)
        {
            _brain.ChangeState(_nextState);
        }
    }
}
