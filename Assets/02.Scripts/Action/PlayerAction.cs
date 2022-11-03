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
    protected virtual int sitHash { get; } = Animator.StringToHash("Sit");
    protected virtual int releaseSitHash { get; } = Animator.StringToHash("ReleaseSit");
    protected virtual PlayerState state { get; private set; }
    protected virtual Animator animator { get; private set; }
    protected virtual Rigidbody2D playerRigid { get; private set; }
    protected virtual SpriteRenderer spriteRenderer { get; private set; }
    protected virtual GameObject basePos { get; private set; }
    protected virtual ParticleSystem particle { get; private set; }

    protected virtual void Awake()
    {

        basePos = GameObject.Find("PlayerBasePos");
        particle = GameObject.Find("PlayerParticle").GetComponent<ParticleSystem>();
        playerRigid = GetComponent<Rigidbody2D>();

        state = GetComponentInChildren<PlayerState>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    public abstract void Action();
    public abstract void Action(float value);

}
