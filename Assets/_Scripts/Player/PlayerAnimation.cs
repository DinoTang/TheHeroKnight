using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : PlayerAbstract
{
    // [Header("Player Animation")]

    private void Update()
    {
        this.SetAnimation();
    }

    protected void SetAnimation()
    {
        this.SetDirection();
        this.SetAnimWalk();
        this.SetSwitchWeapon();
        this.SetAnimAttack();
        this.SetAnimShoot();
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
        this.playerCtrl.Anim.SetBool("Right", this.playerCtrl.PlayerFlipDirect.Right);
        this.playerCtrl.Anim.SetBool("Left", this.playerCtrl.PlayerFlipDirect.Left);
        this.playerCtrl.Anim.SetBool("Down", this.playerCtrl.PlayerFlipDirect.Down);
        this.playerCtrl.Anim.SetBool("Up", this.playerCtrl.PlayerFlipDirect.Up);
    }
    protected void SetAnimAttack()
    {
        this.playerCtrl.Anim.SetBool("Attack", this.playerCtrl.PlayerAttack.Attack);
    }
    protected void SetAnimShoot()
    {
        this.playerCtrl.Anim.SetBool("Shoot", this.playerCtrl.PlayerShooting.Shoot);
    }
}
