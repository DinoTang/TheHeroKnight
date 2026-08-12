using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAbstract
{
    [Header("Player Attack")]
    [SerializeField] protected bool attack;
    public bool Attack => attack;
    [SerializeField] protected float attackTime = 0.5f;
    [SerializeField] protected float attackTimeCounter = 0f;
    [SerializeField] protected bool hitThisSwing;

    private void Update()
    {
        this.GetInputAttack();
        this.Attacking();
    }

    protected void GetInputAttack()
    {
        if (this.playerCtrl.PlayerDamReceive.IsDead) return;
        if (this.playerCtrl.PlayerDamReceive.IsHurt) return;
        if (this.playerCtrl.PlayerMovement.SwitchWeapon) return;
        this.attack = InputManager.Instance.InputAttack;
    }

    public void RegisterHit()
    {
        this.hitThisSwing = true;
    }

    protected void Attacking()
    {
        if (!this.attack) return;
        this.attackTimeCounter += Time.deltaTime;
        if (this.attackTimeCounter < this.attackTime) return;

        if (!this.hitThisSwing)
        {
            AudioManager.Instance.PlaySFX("Sword");
        }
        else
        {
            // AudioManager.Instance.PlaySFX("SwordBlood");
        }

        this.attackTimeCounter = 0f;
        this.hitThisSwing = false;

        this.attack = false;
        InputManager.Instance.SetAttack(false);
    }
}
