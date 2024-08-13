using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationAbtract : DinoBehaviourScript
{
    protected virtual void Update()
    {
        this.SetAnimation();
    }

    protected virtual void SetAnimation()
    {
        this.SetAnimWalk();
        this.SetAnimAttack();
        this.SetAnimShoot();
    }

    protected abstract void SetAnimWalk();

    protected abstract void SetAnimAttack();
    protected virtual void SetAnimShoot()
    {

    }
}
