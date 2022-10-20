using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    public bool IsEnemy { get; }

    public Transform HitPos { get; }

    public void Damage(int damage, GameObject damageFactor);
}
