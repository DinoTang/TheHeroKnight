using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDamReceive : EnemyDamReceive
{
    [Header("Skeleton Dam Receive")]
    [SerializeField] protected int skeletonHpMax = 10;
    [SerializeField] protected float skeletonHurtTime = 0.5f;
    [SerializeField] protected SkeletonCtrl skeletonCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSkeletonCtrl();
    }
    protected void LoadSkeletonCtrl()
    {
        if (this.skeletonCtrl != null) return;
        this.skeletonCtrl = GetComponentInParent<SkeletonCtrl>();
        Debug.Log(transform.name + ": LoadSkeletonCtrl", gameObject);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    protected override void Reborn()
    {
        this.hpMax = this.skeletonHpMax;
        this.hurtTime = this.skeletonHurtTime;
        this.collide.enabled = true;
        this.SetRigidConstraint();
        base.Reborn();
    }
    protected override void OnDead()
    {
        base.OnDead();
        this.skeletonCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        this.collide.enabled = false;
    }
    protected override void Hurt()
    {
        this.skeletonCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    protected override void SetRigidConstraint()
    {
        this.skeletonCtrl.Rigid.constraints = RigidbodyConstraints2D.None;
        this.skeletonCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    protected void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            this.skeletonCtrl.EnemyMovement.SetNewDestination();
    }
}
