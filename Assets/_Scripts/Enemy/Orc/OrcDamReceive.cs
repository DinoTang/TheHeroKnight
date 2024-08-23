using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcDamReceive : EnemyDamReceive
{
    [Header("Orc Dam Receive")]
    [SerializeField] protected int orcHpMax = 10;
    [SerializeField] protected float orcHurtTime = 0.5f;
    [SerializeField] protected OrcCtrl orcCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadOrcCtrl();
    }
    protected void LoadOrcCtrl()
    {
        if (this.orcCtrl != null) return;
        this.orcCtrl = GetComponentInParent<OrcCtrl>();
        Debug.Log(transform.name + ": LoadOrcCtrl", gameObject);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    protected override void Reborn()
    {
        this.hpMax = this.orcHpMax;
        this.hurtTime = this.orcHurtTime;
        this.collide.enabled = true;
        this.SetRigidConstraint();
        base.Reborn();
    }
    protected override void OnDead()
    {
        base.OnDead();
        this.orcCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        this.collide.enabled = false;
    }
    protected override void Hurt()
    {
        this.orcCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    protected override void SetRigidConstraint()
    {
        this.orcCtrl.Rigid.constraints = RigidbodyConstraints2D.None;
        this.orcCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    protected void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            this.orcCtrl.EnemyMovement.SetNewDestination();
    }
}
