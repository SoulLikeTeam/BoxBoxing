using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : PlayerAction
{
    public override void Action(Animator animator, PlayerState state)
    {

        if (state.currentState != Define.PlayerStates.Idle) return;

        animator.SetTrigger(guardHash);
        state.SetState(Define.PlayerStates.Guard);

    }

}
