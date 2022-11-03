using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAIsAttackCondition : PACondition
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    public override bool IfCondition(PAState currState, PAState nexState)
    {
        return enemy.IsPunch;
    }
}
