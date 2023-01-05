using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseGuard : PlayerAction
{

    public override void Action()
    {

        if (!playerManagement.isFuckingDie)
        {

            if (state.currentState != Define.PlayerStates.Guard) return;

        }
        else
        {

            GetComponent<ShieldUp>().DeShield(false);

        }
        
        animator.SetTrigger(releaseGuardHash);
        state.SetIdle();
        playerManagement.DeGuard();

    }

    public override void Action(float value)
    {
    }

}
