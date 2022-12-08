using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAPunchState : PAState
{
    [SerializeField]
    private float punchTime = 0.3f;
    [SerializeField]
    private float _attackRange = 2f;

    private PAState _nextState;

    public override void OnStateEnter()
    {
        do
        {
            _nextState = _transitionList[Random.Range(0, _transitionList.Count)].nextState;
        } while (_nextState == null);


        //_enemy?.OnPunchAction?.Invoke();
        // �� �ٶ󺸱�

        bool dir = _enemy.transform.position.x < _brain.Target.transform.position.x;
        _enemy.ActionList[(int)StateType.Moving].Action(dir ? 1 : -1);
        _enemy.ActionList[(int)StateType.Punch].Action();

        //���⿡ ���� �ֱ�

        //GameObject.Find("Player").GetComponentInChildren<PlayerManagement>().Hit();
    }

    public override void OnStateLeave()
    {

    }

    public override void PlayerAction()
    {
        //_playerAction?.Action();

        if (_brain.StateDuractionTime >= punchTime)
        {
            float distance = _brain.Target.transform.position.x - _enemy.transform.position.x;
            if (Mathf.Abs(distance) <= _attackRange)
            {
                PlayerManagement player = _brain.Target.GetComponentInChildren<PlayerManagement>();
                player?.Hit();
            }
            _brain.ChangeState(_nextState);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.white;
    }
#endif
}
