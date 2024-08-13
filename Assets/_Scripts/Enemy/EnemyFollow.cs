using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyAbstract
{
    [Header("Enemy Follow")]
    [SerializeField] protected Transform target;

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
    protected void FixedUpdate()
    {
        this.Following();
    }
    protected void Following()
    {
        if (!this.enemyCtrl.EnemyDetect.IsDetect) return;

        transform.parent.position = Vector2.MoveTowards(transform.position, this.target.position,
        this.enemyCtrl.EnemyMovement.Speed * Time.fixedDeltaTime);
    }
}
