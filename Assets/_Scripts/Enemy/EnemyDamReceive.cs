using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceive : DamageReceiver
{
    [Header("Enemy Dam Receive")]
    [SerializeField] protected int enemyHpMax = 10;
    [SerializeField] protected float enemyHurtTime = 0.5f;
    [SerializeField] protected CapsuleCollider2D collide;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollide();
    }
    protected void LoadCollide()
    {
        if (this.collide != null) return;
        this.collide = GetComponent<CapsuleCollider2D>();
        Debug.Log(transform.name + ": LoadCollide", gameObject);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    protected override void Reborn()
    {
        this.hpMax = this.enemyHpMax;
        this.hurtTime = this.enemyHurtTime;
        this.collide.enabled = true;
        this.SetRigidConstraint();
        base.Reborn();
    }
    protected override void OnDead()
    {
        base.OnDead();
        this.enemyCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        this.collide.enabled = false;
    }
    protected override void Hurt()
    {
        this.enemyCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    protected override void StopHurt()
    {
        base.StopHurt();
        this.SetRigidConstraint();
    }
    protected void SetRigidConstraint()
    {
        this.enemyCtrl.Rigid.constraints = RigidbodyConstraints2D.None;
        this.enemyCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    protected void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            this.enemyCtrl.EnemyMovement.SetNewDestination();
    }
}
