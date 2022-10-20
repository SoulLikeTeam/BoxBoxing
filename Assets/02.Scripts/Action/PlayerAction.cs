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

    public abstract void Action(Animator animator, PlayerState state);

}
