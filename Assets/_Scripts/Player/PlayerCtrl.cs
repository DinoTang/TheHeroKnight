using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : DinoBehaviourScript
{
    [Header("Player Ctrl")]
    [SerializeField] protected Animator anim;
    [SerializeField] protected PlayerMovement playerMovement;
    [SerializeField] protected PlayerAttack playerAttack;
    [SerializeField] protected PlayerAttackArea playerAttackArea;
    public Animator Anim => anim;
    public PlayerMovement PlayerMovement => playerMovement;
    public PlayerAttack PlayerAttack => playerAttack;
    public PlayerAttackArea PlayerAttackArea => playerAttackArea;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
        this.LoadPlayerMovement();
        this.LoadPlayerAttack();
    }

    protected void LoadAnimator()
    {
        if (this.anim != null) return;
        this.anim = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ":LoadAnimator", gameObject);
    }

    protected void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = GetComponentInChildren<PlayerMovement>();
        Debug.Log(transform.name + ":LoadPlayerMovement", gameObject);
    }
    protected void LoadPlayerAttack()
    {
        if (this.playerAttack != null) return;
        this.playerAttack = GetComponentInChildren<PlayerAttack>();
        Debug.Log(transform.name + ":LoadPlayerAttack", gameObject);
    }

}
