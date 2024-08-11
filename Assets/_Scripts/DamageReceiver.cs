using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : DinoBehaviourScript
{
    [Header("Damage Receiver")]
    [SerializeField] protected int hp;
    [SerializeField] protected int hpMax = 10;
    [SerializeField] protected bool dead;
    public int Hp => hp;
    public int HPMax => hpMax;
    public bool Dead => dead;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }
    protected void Reborn()
    {
        this.hp = hpMax;
        this.dead = false;
    }
    protected virtual void Add(int hp)
    {
        if (this.dead) return;
        this.hp += hp;
        if (this.hp >= this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(int damage)
    {
        if (this.dead) return;
        this.hp -= damage;
        if (this.hp <= 0) this.hp = 0;
        this.IsDead();
    }

    protected void IsDead()
    {
        if (!this.dead) return;
        this.dead = true;
    }
}
