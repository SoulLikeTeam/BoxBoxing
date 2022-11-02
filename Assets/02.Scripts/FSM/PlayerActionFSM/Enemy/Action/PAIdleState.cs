using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAIdleState : PAState
{
    public override void OnStateEnter()
    {
        
    }

    public override void OnStateLeave()
    {
        
    }

    public override void PlayerAction()
    {
        _playerAction?.Action();
    }
}
