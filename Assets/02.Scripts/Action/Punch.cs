using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Punch : PlayerAction
{

    private bool isCool;

    public override void Action()
    {

        if ((state.currentState != Define.PlayerStates.Idle && state.currentState != Define.PlayerStates.Walk) || isCool) return;

        animator.SetTrigger(punchHash);
        animator.SetFloat(punchCountHash, Random.Range(0, 2));

        state.SetState(Define.PlayerStates.Punch);

        playerRigid.velocity = Vector2.zero;

        playerManagement.Attack();

        SoundManager.instance.SFXPlay(Random.Range(6, 8));

        isCool = true;

        FAED.InvokeDelay(() =>
        {

            isCool = false;

        }, 1f);

    }

}
