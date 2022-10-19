using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseGuard : PlayerAction
{
    public override void Action(Animator animator, PlayerState state)
    {

        if (state.currentState != Define.PlayerStates.Guard) return;

        animator.SetTrigger(releaseGuardHash);
        state.SetIdle();

    }

}
