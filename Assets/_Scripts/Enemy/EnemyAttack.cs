using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyAbstract
{
    [Header("Enemy Attack")]
    [SerializeField] protected Transform enemyDamSender;
    [SerializeField] protected bool isAttack;
    [SerializeField] protected float distance;
    [SerializeField] protected float disLimit = 2f;
    [SerializeField] protected float attackTime = 0.5f;
    [SerializeField] protected float attackTimeCounter = 0f;
    [SerializeField] protected float attackCoolDown = 2f;
    [SerializeField] protected float attackCoolDownCounter = 0f;
    public bool IsAttack => isAttack;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyDamSender();
    }
    protected void LoadEnemyDamSender()
    {
        if (this.enemyDamSender != null) return;
        this.enemyDamSender = transform.parent.Find("EnemyDamSender");
        Debug.Log(transform.name + ": LoadEnemyDamSender", gameObject);
    }
    protected void Update()
    {
        this.Attacking();
    }
    protected void Attacking()
    {
        if (this.enemyCtrl.EnemyDamReceive.IsDead) return;
        if (!this.enemyCtrl.EnemyDetect.Detect)
        {
            this.isAttack = false;
            return;
        }
        if (this.enemyCtrl.EnemyDamReceive.IsHurt)
        {
            this.SetAttackTime();
            return;
        }
        if (this.CanAttack()) this.Attack();
        this.StopAttack();
        this.TimeCooldown();
    }
    protected bool CanAttack()
    {
        this.distance = Vector3.Distance(transform.parent.position, this.enemyCtrl.EnemyFollow.Target.position);
        if (this.distance <= this.disLimit && this.attackCoolDownCounter <= 0f)
            return true;
        return false;
    }
    protected void Attack()
    {
        this.isAttack = true;
        this.enemyDamSender.gameObject.SetActive(true);
        this.SetAttackTime();
    }
    protected void StopAttack()
    {
        if (this.attackTimeCounter <= 0f && this.isAttack)
        {
            this.isAttack = false;
            this.enemyDamSender.gameObject.SetActive(false);
        }
    }
    protected void TimeCooldown()
    {
        if (this.attackTimeCounter <= 0f && this.attackCoolDownCounter <= 0f) return;
        this.attackCoolDownCounter -= Time.deltaTime;
        this.attackTimeCounter -= Time.deltaTime;
    }
    protected void SetAttackTime()
    {
        this.attackTimeCounter = this.attackTime;
        this.attackCoolDownCounter = this.attackCoolDown + this.attackTime;
    }
}
