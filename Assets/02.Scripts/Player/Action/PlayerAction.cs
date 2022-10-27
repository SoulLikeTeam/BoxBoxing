using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class PlayerAction : MonoBehaviour
{

    protected virtual int punchHash { get; } = Animator.StringToHash("Punch");
    protected virtual int punchCountHash { get; } = Animator.StringToHash("PunchCount");
    protected virtual int guardHash { get; } = Animator.StringToHash("Guard");
    protected virtual int releaseGuardHash { get; } = Animator.StringToHash("DeGuard");
    protected virtual int hitHash { get; } = Animator.StringToHash("Hit");
    protected virtual PlayerState state { get; private set; }
    protected virtual Animator animator { get; private set; }
    protected virtual Rigidbody2D playerRigid { get; private set; }
    protected virtual SpriteRenderer spriteRenderer { get; private set; }
    protected virtual GameObject basePos { get; private set; }

    protected virtual void Awake()
    {

        state = FindObjectOfType<PlayerState>();
        animator = GameObject.Find("Player").GetComponentInChildren<Animator>();
        playerRigid = GameObject.Find("Player").GetComponentInChildren<Rigidbody2D>();
        spriteRenderer = GameObject.Find("Player").GetComponentInChildren<SpriteRenderer>();
        basePos = GameObject.Find("PlayerBasePos");

    }

    public abstract void Action();
    public abstract void Action(float value);

}
