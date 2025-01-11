using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : HitBox
{
    [SerializeField] private Pool _bloodPool;

    public override void Hit(Rapier rapier)
    {
        base.Hit(rapier);
        _bloodPool.GetFreeElement(rapier.Hit.point);
    }
}