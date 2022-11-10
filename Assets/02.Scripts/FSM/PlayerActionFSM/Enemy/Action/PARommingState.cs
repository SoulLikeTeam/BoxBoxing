using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PARommingState : PAState
{
    [SerializeField]
    private float minMoveTime;
    [SerializeField]
    private float maxMoveTime;

    private float time;

    private bool isLeft = false;

    public override void OnStateEnter()
    {
        time = GetNextMoveTime();
        GetDirection();
    }

    public override void OnStateLeave()
    {
        _playerAction?.Action(0);
    }

    public override void PlayerAction()
    {
        // 이동 처리

        _playerAction?.Action(isLeft ? -1 : 1);

        if((_brain.StateDuractionTime >= time)/* || (Mathf.Abs(_brain.Enemy.transform.position - )*/)
        {
            _brain.ChangeState(_transitionList[Random.Range(0, _transitionList.Count)].nextState);
        }
    }

    public float GetNextMoveTime()
    {
        float time = Random.Range(minMoveTime, maxMoveTime);
        return time;
    }

    public void GetDirection()
    {
        GameScene scene = Managers.Scene.CurrentScene as GameScene;

        bool left = transform.position.x < 0;
        float distance = 0;
        if(left == true) // 왼쪽
        {
            distance = Mathf.Abs(_brain.Enemy.transform.position.x - scene.MinXPos);
        }
        else // 오른쪽
        {
            distance = Mathf.Abs(_brain.Enemy.transform.position.x - scene.MaxXPos);
        }

        if(distance < 2) // 링 안 쪽으로
        {
            isLeft = true;
        }
        else // 바깥쪽으로
        {
            isLeft = false;
        }
    }
}
