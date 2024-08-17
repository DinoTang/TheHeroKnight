using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : DinoBehaviourScript
{
    [Header("Enemy Ctrl")]
    [SerializeField] protected Animator anim;
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected EnemyMovement enemyMovement;
    [SerializeField] protected EnemyFlipDirect enemyFlipDirect;
    [SerializeField] protected EnemyFollow enemyFollow;
    [SerializeField] protected EnemyDetectPlayer enemyDetect;
    [SerializeField] protected EnemyAttack enemyAttack;
    [SerializeField] protected EnemyDamReceive enemyDamReceive;
    public Animator Anim => anim;
    public Rigidbody2D Rigid => rigid;
    public EnemyMovement EnemyMovement => enemyMovement;
    public EnemyFlipDirect EnemyFlipDirect => enemyFlipDirect;
    public EnemyFollow EnemyFollow => enemyFollow;
    public EnemyDetectPlayer EnemyDetect => enemyDetect;
    public EnemyAttack EnemyAttack => enemyAttack;
    public EnemyDamReceive EnemyDamReceive => enemyDamReceive;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
        this.LoadRigidbody();
        this.LoadEnemyMovement();
        this.LoadEnemyFlipDirect();
        this.LoadEnemyFollow();
        this.LoadEnemyDetect();
        this.LoadEnemyAttack();
        this.LoadEnemyDamReceive();
    }
    protected void LoadAnimator()
    {
        if (this.anim != null) return;
        this.anim = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ":LoadAnimator", gameObject);
    }
    protected void LoadRigidbody()
    {
        if (this.rigid != null) return;
        this.rigid = GetComponentInChildren<Rigidbody2D>();
        Debug.Log(transform.name + ":LoadRigidbody", gameObject);
    }
    protected void LoadEnemyMovement()
    {
        if (this.enemyMovement != null) return;
        this.enemyMovement = GetComponentInChildren<EnemyMovement>();
        Debug.Log(transform.name + ": LoadEnemyMovement", gameObject);
    }
    protected void LoadEnemyFlipDirect()
    {
        if (this.enemyFlipDirect != null) return;
        this.enemyFlipDirect = GetComponentInChildren<EnemyFlipDirect>();
        Debug.Log(transform.name + ": LoadEnemyFlipDirect", gameObject);
    }
    protected void LoadEnemyFollow()
    {
        if (this.enemyFollow != null) return;
        this.enemyFollow = GetComponentInChildren<EnemyFollow>();
        Debug.Log(transform.name + ":LoadEnemyFollow", gameObject);
    }
    protected void LoadEnemyDetect()
    {
        if (this.enemyDetect != null) return;
        this.enemyDetect = GetComponentInChildren<EnemyDetectPlayer>();
        Debug.Log(transform.name + ":LoadEnemyDetect", gameObject);
    }
    protected void LoadEnemyAttack()
    {
        if (this.enemyAttack != null) return;
        this.enemyAttack = GetComponentInChildren<EnemyAttack>();
        Debug.Log(transform.name + ":LoadEnemyAttack", gameObject);
    }
    protected void LoadEnemyDamReceive()
    {
        if (this.enemyDamReceive != null) return;
        this.enemyDamReceive = GetComponentInChildren<EnemyDamReceive>();
        Debug.Log(transform.name + ":LoadEnemyDamReceive", gameObject);
    }
}
