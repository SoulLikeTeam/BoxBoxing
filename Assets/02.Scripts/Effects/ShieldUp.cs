using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : PlayerAction
{

    [SerializeField] private Sprite[] sprite;
    [SerializeField] private Sprite[] lowShieldSprite;
    [SerializeField] private new SpriteRenderer spriteRenderer;

    public override void Action()
    {
    }

    public void Shield(int count, bool isLow = false)
    {

        if (!isLow)
        {

            spriteRenderer.sprite = sprite[count];
            if (count == 0) 
            { 
                spriteRenderer.sprite = null;
                animator.SetTrigger(releaseGuardHash);
                state.SetIdle();
            }

        }
        else
        {

            spriteRenderer.sprite = null;
            spriteRenderer.sprite = lowShieldSprite[count];
            if (count == 0)
            {
                spriteRenderer.sprite = null;
                animator.SetTrigger(releaseGuardHash);
                state.SetIdle();
            }

        }

    }

    public void DeShield()
    {

        spriteRenderer.sprite = null;
        animator.SetTrigger(releaseGuardHash);
        state.SetIdle();

    }

}
