using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : PlayerAction
{

    [SerializeField] private float speed;

    public override void Action()
    {
    }

    public override void Action(float value)
    {

        transform.Translate(new Vector2(value * speed, playerRigid.velocity.y));

        basePos.transform.localScale = value switch
        {
        
            1 => new Vector3(1, 1, 1),
            -1 => new Vector3(-1, 1, 1),
            _ => basePos.transform.localScale

        };

    }
}
