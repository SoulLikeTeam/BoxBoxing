using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;
using UnityEngine.Accessibility;

public class Sit : PlayerAction
{

    [SerializeField] private Animator boxAnime;

    private bool isCool;

    public override void Action()
    {

        if ((state.currentState != Define.PlayerStates.Idle && state.currentState != Define.PlayerStates.Walk) || isCool) return;
        
        animator.SetTrigger(sitHash);
        state.SetState(Define.PlayerStates.Sit);
        playerRigid.velocity = Vector2.zero;
        boxAnime.SetTrigger(close);

        isCool = true;

        playerManagement.godMode = true;

        FAED.InvokeDelay(() =>
        {

            if(state.currentState == Define.PlayerStates.Sit) animator.SetTrigger(releaseSitHash);
            isCool = false;
            playerManagement.godMode = false;

        }, 2f);

    }

}
