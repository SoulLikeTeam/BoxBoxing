using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Punch : PlayerAction
{
    public override void Action()
    {

        if (state.currentState != Define.PlayerStates.Idle) return;

        animator.SetTrigger(punchHash);
        animator.SetFloat(punchCountHash, Random.Range(0, 2));
        state.SetState(Define.PlayerStates.Punch);
        playerRigid.velocity = Vector2.zero;
        PlayerManagement.Instance.Attack();

    }

    public override void Action(float value)
    {
    }

}
