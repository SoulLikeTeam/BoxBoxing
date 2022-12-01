using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Punch : PlayerAction
{
    public override void Action()
    {

        if (state.currentState != Define.PlayerStates.Idle && state.currentState != Define.PlayerStates.Walk) return;

        animator.SetTrigger(punchHash);
        animator.SetFloat(punchCountHash, Random.Range(0, 2));
        state.SetState(Define.PlayerStates.Punch);
        playerRigid.velocity = Vector2.zero;
        playerManagement.Attack();
    }

}
