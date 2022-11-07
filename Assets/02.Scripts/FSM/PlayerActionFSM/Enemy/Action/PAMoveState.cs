using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAMoveState : PAState
{
    RaycastHit2D frontRay;
    RaycastHit2D backRay;

    [SerializeField]
    private float _distance = 3f;
    [SerializeField]
    private LayerMask _layerMask;

    private float _moveDirection = 0;

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateLeave()
    {
        
    }

    public override void PlayerAction()
    {
        _playerAction?.Action(_moveDirection);
    }
}
