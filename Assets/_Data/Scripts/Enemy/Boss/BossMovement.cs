using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : DinoBehaviourScript
{
    [SerializeField] protected Transform target;
    [SerializeField] protected BossAttack1 bossAttack1;
    [SerializeField] protected float distance;
    [SerializeField] protected float distanceToTarget;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
    }
    protected void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }
    protected void Update()
    {
        this.Move();
    }
    public bool CanMove()
    {
        this.distance = Vector2.Distance(transform.parent.position, target.position);
        if (this.distance <= this.distanceToTarget) return true;
        return false;
    }
    protected void Move()
    {
        if (!this.CanMove()) return;
        this.bossAttack1.enabled = true;
    }
}
