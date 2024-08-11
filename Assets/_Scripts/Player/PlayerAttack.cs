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

    protected void Update()
    {
        this.GetInputAttack();
        this.SetTimeAttack();
    }

    protected void GetInputAttack()
    {
        if (Input.GetKeyDown(KeyCode.J)) this.attack = true;
    }

    protected void SetTimeAttack()
    {
        if (!this.attack) return;

        this.attackTimeCounter += Time.deltaTime;
        if (this.attackTimeCounter < this.attackTime) return;
        this.attackTimeCounter = 0f;

        this.attack = false;
    }
}
