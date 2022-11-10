using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sit : PlayerAction
{
    public override void Action()
    {

        if (state.currentState != Define.PlayerStates.Idle && state.currentState != Define.PlayerStates.Walk) return;
        
        animator.SetTrigger(sitHash);
        state.SetState(Define.PlayerStates.Sit);
        playerRigid.velocity = Vector2.zero;

    }

}
