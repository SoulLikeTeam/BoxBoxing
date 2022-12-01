using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hit : PlayerAction
{

    [SerializeField] private UnityEvent effectEvent;

    public override void Action()
    {

        if (state.currentState == Define.PlayerStates.Die) return;
        playerRigid.velocity = Vector3.zero;
        animator.SetTrigger(hitHash);
        effectEvent?.Invoke();

    }

    public override void Action(float value)
    {

    }
}
