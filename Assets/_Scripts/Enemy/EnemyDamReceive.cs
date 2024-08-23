using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceive : DamageReceiver
{
    [Header("Enemy Dam Receive")]
    [SerializeField] protected CapsuleCollider2D collide;
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
    protected override void StopHurt()
    {
        base.StopHurt();
        this.SetRigidConstraint();
    }
    protected virtual void SetRigidConstraint()
    {
        
    }
    
}
