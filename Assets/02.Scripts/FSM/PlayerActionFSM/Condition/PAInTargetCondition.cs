using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAInTargetCondition : PACondition
{
    [SerializeField]
    private float range;

    public override bool IfCondition(PAState currState, PAState nexState)
    {
        return Mathf.Abs(_brain.Target.transform.position.x - _brain.Enemy.transform.position.x) <= range;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.white;
    }
#endif
}
