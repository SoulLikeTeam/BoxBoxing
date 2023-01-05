using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : PlayerAction
{

    
    private bool isGuardCool;

    public override void Action()
    {
        if (playerManagement.isFuckingDie)
        {

            GetComponent<ShieldUp>().None();

        }


        if (state.currentState != Define.PlayerStates.Idle && state.currentState != Define.PlayerStates.Walk || isGuardCool) return;
        
        state.SetState(Define.PlayerStates.Guard);
        playerRigid.velocity = Vector2.zero;
        playerManagement.SetGuard();
        animator.SetTrigger(guardHash);        

        isGuardCool = true;


        FAED.InvokeDelayReal(() =>
        {

            isGuardCool = false;

        }, 4f);

    }

}
