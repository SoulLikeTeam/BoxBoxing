using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : PlayerAction
{

    [SerializeField] private Sprite[] sprite;
    [SerializeField] private new SpriteRenderer spriteRenderer;

    public override void Action()
    {
    }

    public void Shield(int count)
    {

        if (count == 0) animator.SetTrigger(releaseGuardHash);
        state.SetIdle();
        spriteRenderer.sprite = sprite[count];

    }

}
