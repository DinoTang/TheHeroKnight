using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : DinoBehaviourScript
{
    [Header("Enemy Ctrl")]
    [SerializeField] protected Animator anim;
    [SerializeField] protected EnemyMovement enemyMovement;
    public Animator Anim => anim;
    public EnemyMovement EnemyMovement => enemyMovement;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
        this.LoadEnemyMovement();
    }
    protected void LoadEnemyMovement()
    {
        if (this.enemyMovement != null) return;
        this.enemyMovement = GetComponentInChildren<EnemyMovement>();
        Debug.Log(transform.name + ": LoadEnemyMovement", gameObject);
    }
    protected void LoadAnimator()
    {
        if (this.anim != null) return;
        this.anim = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ":LoadAnimator", gameObject);
    }
}
