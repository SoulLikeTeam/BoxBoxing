using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : PlayerAction
{
    public override void Action()
    {

        if (state.currentState != Define.PlayerStates.Idle) return;

        animator.SetTrigger(guardHash);
        state.SetState(Define.PlayerStates.Guard);

    }

    public override void Action(float value)
    {
    }
}
