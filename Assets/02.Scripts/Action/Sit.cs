using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;
using UnityEngine.Accessibility;

public class Sit : PlayerAction
{

    private bool isCool;

    public override void Action()
    {

        if ((state.currentState != Define.PlayerStates.Idle && state.currentState != Define.PlayerStates.Walk) || isCool) return;
        
        animator.SetTrigger(sitHash);
        state.SetState(Define.PlayerStates.Sit);
        playerRigid.velocity = Vector2.zero;

        isCool = true;

        FAED.InvorkDelay(() =>
        {

            isCool = false;

        }, 2f);

    }

}
