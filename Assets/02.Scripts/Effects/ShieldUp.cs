using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows;

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
            if (lowShieldSprite.Length > 0 && lowShieldSprite[count] != null)
                spriteRenderer.sprite = lowShieldSprite[count];
            if (count == 0)
            {
                spriteRenderer.sprite = null;
                animator.SetTrigger(releaseGuardHash);
                state.SetIdle();
            }

        }

    }

    public void DeShield(bool isBreak)
    {

        if (isBreak)
        {

            if (gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
            {

                FindObjectOfType<PlayerInput>().SetIgnoreInput(true);

                FAED.InvokeDelay(() =>
                {

                    FindObjectOfType<PlayerInput>().SetIgnoreInput(false);

                }, 1.5f);

            }
            else
            {

                FindObjectOfType<Enemy>().IsBattle = false;

                FAED.InvokeDelay(() =>
                {

                    FindObjectOfType<Enemy>().IsBattle = true;

                }, 1.5f);

            }

        }

        spriteRenderer.sprite = null;
        animator.SetTrigger(releaseGuardHash);
        state.SetIdle();

    }

}
