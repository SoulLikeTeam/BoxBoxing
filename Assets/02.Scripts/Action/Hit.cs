using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : PlayerAction
{
    public override void Action(Animator animator, PlayerState state)
    {

        animator.SetTrigger(hitHash);
        state.SetState(Define.PlayerStates.Die);

    }

}
