using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDamReceive : EnemyDamReceive
{
    protected override void OnDead()
    {
        base.OnDead();
        AudioManager.Instance.PlaySFX("SkeletonDeath");
    }
}
