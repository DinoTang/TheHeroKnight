using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamReceive : EnemyDamReceive
{
    [Header("Boss Dam Receive")]
    [SerializeField] protected int bossHpMax = 100;
    [SerializeField] protected BossCtrl bossCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossCtrl();
    }
    protected void LoadBossCtrl()
    {
        if (this.bossCtrl != null) return;
        this.bossCtrl = GetComponentInParent<BossCtrl>();
        Debug.Log(transform.name + ": LoadBossCtrl", gameObject);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    protected override void Reborn()
    {
        this.hpMax = this.bossHpMax;
        base.Reborn();
    }
    protected override void OnDead()
    {
        base.OnDead();
        this.collide.enabled = false;
    }
}
