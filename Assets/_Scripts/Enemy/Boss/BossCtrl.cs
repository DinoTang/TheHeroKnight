using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossCtrl : EnemyCtrl
{
    [Header("Boss Ctrl")]
    [SerializeField] protected Animator anim;
    public Animator Anim => anim;
    [SerializeField] protected BossFlipDirect bossFlipDirect;
    public BossFlipDirect BossFlipDirect => bossFlipDirect;
    [SerializeField] protected BossAttackCtrl bossAttackCtrl;
    public BossAttackCtrl BossAttackCtrl => bossAttackCtrl;
    [SerializeField] protected BossDamReceive bossDamReceive;
    public BossDamReceive BossDamReceive => bossDamReceive;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimation();
        this.LoadBossFlipDirect();
        this.LoadBossAttackCtrl();
        this.LoadBossDamReceive();
    }
    protected void LoadAnimation()
    {
        if (this.anim != null) return;
        this.anim = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimation", gameObject);
    }
    protected void LoadBossFlipDirect()
    {
        if (this.bossFlipDirect != null) return;
        this.bossFlipDirect = GetComponentInChildren<BossFlipDirect>();
        Debug.Log(transform.name + ": LoadBossFlipDirect", gameObject);
    }
    protected void LoadBossAttackCtrl()
    {
        if (this.bossAttackCtrl != null) return;
        this.bossAttackCtrl = GetComponentInChildren<BossAttackCtrl>();
        Debug.Log(transform.name + ": LoadBossAttackCtrl", gameObject);
    }
    protected void LoadBossDamReceive()
    {
        if (this.bossDamReceive != null) return;
        this.bossDamReceive = GetComponentInChildren<BossDamReceive>();
        Debug.Log(transform.name + ": LoadBossDamReceive", gameObject);
    }
}
