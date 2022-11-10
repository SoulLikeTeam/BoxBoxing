using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseGuard : PlayerAction
{
    public override void Action()
    {

        if (state.currentState != Define.PlayerStates.Guard) return;

        animator.SetTrigger(releaseGuardHash);
        state.SetIdle();

    }

    public override void Action(float value)
    {
    }
}
