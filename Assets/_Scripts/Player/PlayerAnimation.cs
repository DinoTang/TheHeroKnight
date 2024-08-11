using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : PlayerAbstract
{
    // [Header("Player Animation")]

    protected void Update()
    {
        this.SetAnimation();
    }

    protected void SetAnimation()
    {
        this.SetDirection();
        this.SetAnimWalk();
        this.SetSwitchWeapon();
        this.SetAnimAttack();
    }

    protected void SetAnimWalk()
    {
        this.playerCtrl.Anim.SetFloat("velocity.x", this.playerCtrl.PlayerMovement.Horizontal);
        this.playerCtrl.Anim.SetFloat("velocity.y", this.playerCtrl.PlayerMovement.Vertical);
    }
    protected void SetSwitchWeapon()
    {
        this.playerCtrl.Anim.SetBool("SwitchWeapon", this.playerCtrl.PlayerMovement.SwitchWeapon);
    }

    protected void SetDirection()
    {
        this.playerCtrl.Anim.SetBool("Right", this.playerCtrl.PlayerMovement.Right);
        this.playerCtrl.Anim.SetBool("Left", this.playerCtrl.PlayerMovement.Left);
        this.playerCtrl.Anim.SetBool("Down", this.playerCtrl.PlayerMovement.Down);
        this.playerCtrl.Anim.SetBool("Up", this.playerCtrl.PlayerMovement.Up);
    }
    protected void SetAnimAttack()
    {
        this.playerCtrl.Anim.SetBool("Attack", this.playerCtrl.PlayerAttack.Attack);
    }
}
