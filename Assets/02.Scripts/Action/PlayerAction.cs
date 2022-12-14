using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class PlayerAction : MonoBehaviour
{

    protected readonly int punchHash = Animator.StringToHash("Punch");
    protected readonly int punchCountHash = Animator.StringToHash("PunchCount");
    protected readonly int guardHash = Animator.StringToHash("Guard");
    protected readonly int releaseGuardHash = Animator.StringToHash("DeGuard");
    protected readonly int hitHash = Animator.StringToHash("Hit");
    protected readonly int sitHash = Animator.StringToHash("Sit");
    protected readonly int releaseSitHash = Animator.StringToHash("ReleaseSit");
    protected readonly int open = Animator.StringToHash("Open");
    protected readonly int close = Animator.StringToHash("Close");

    protected virtual GameObject basePos { get; private set; }
    protected PlayerState state { get; private set; }
    public PlayerState State => state;
    protected Animator animator { get; private set; }
    protected Rigidbody2D playerRigid { get; private set; }
    protected SpriteRenderer spriteRenderer { get; private set; }
    protected ParticleSystem particle { get; private set; }
    protected ParticleSystem boxParticle { get; private set; }
    protected PlayerManagement playerManagement { get; private set; }

    protected virtual void Awake()
    {

        basePos = transform.Find("PlayerBasePos").gameObject;
        particle = basePos.transform.Find("PlayerParticle").GetComponent<ParticleSystem>();
        boxParticle = basePos.transform.Find("BoxParticle").GetComponent<ParticleSystem>();
        playerRigid = GetComponent<Rigidbody2D>();
        playerManagement = GetComponent<PlayerManagement>();

        state = GetComponentInChildren<PlayerState>();
        animator = basePos.transform.Find("VisualSprite").GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    public abstract void Action();
    public virtual void Action(float value)
    {
    }

}
