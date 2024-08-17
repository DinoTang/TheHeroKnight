using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : AnimationAbtract
{
    [Header("Enemy Animation")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }
    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected override void SetAnimWalk()
    {
        this.enemyCtrl.Anim.SetBool("Moving", this.enemyCtrl.EnemyMovement.IsMoving);
    }
    protected override void SetAnimAttack()
    {
        this.enemyCtrl.Anim.SetBool("Attack", this.enemyCtrl.EnemyAttack.IsAttack);
    }
    protected override void SetAnimHurt()
    {
        this.enemyCtrl.Anim.SetBool("Hurt", this.enemyCtrl.EnemyDamReceive.IsHurt);
    }
    protected override void SetAnimDead()
    {
        this.enemyCtrl.Anim.SetBool("Dead", this.enemyCtrl.EnemyDamReceive.IsDead);
    }
}
