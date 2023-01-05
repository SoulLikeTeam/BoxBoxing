using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class ReleaseSit : PlayerAction
{

    [SerializeField] private Animator boxAnime;

    public override void Action()
    {

        if (state.currentState != Define.PlayerStates.Sit) return;

        boxAnime.SetTrigger(open);

        animator.SetTrigger(releaseSitHash);

        state.SetIdle();

    }

    public void ResetDel()
    {


    }

    private void Update()
    {


    }

    public override void Action(float value)
    {
    }
}
