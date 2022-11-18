using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PASitState : PAState
{
    public override void OnStateEnter()
    {
        _enemy?.OnSitAction?.Invoke();
    }

    public override void OnStateLeave()
    {
        _enemy?.OnUnSitAction?.Invoke();
    }

    public override void PlayerAction()
    {
    }
}
