using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : PlayerAction
{

    public override void Action()
    {

        if (state.currentState != Define.PlayerStates.Idle && state.currentState != Define.PlayerStates.Walk) return;

        animator.SetTrigger(guardHash);
        state.SetState(Define.PlayerStates.Guard);
        playerRigid.velocity = Vector2.zero;
        playerManagement.SetGuard();

    }

}
