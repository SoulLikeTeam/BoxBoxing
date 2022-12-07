using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseSit : PlayerAction
{
    public override void Action()
    {

        if (state.currentState != Define.PlayerStates.Sit) return;

        animator.SetTrigger(releaseSitHash);

        state.SetIdle();

        playerManagement.DeGuard();

    }

    public override void Action(float value)
    {
    }
}
