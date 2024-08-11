using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : DinoBehaviourScript
{
    [Header("Damage Receiver")]
    [SerializeField] protected int hp;
    [SerializeField] protected int hpMax = 10;
    [SerializeField] protected bool isDead;
    public int Hp => hp;
    public int HPMax => hpMax;
    public bool IsDead => isDead;
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
        this.isDead = false;
    }
    protected virtual void Add(int hp)
    {
        if (this.isDead) return;
        this.hp += hp;
        if (this.hp >= this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(int damage)
    {
        if (this.isDead) return;
        this.hp -= damage;
        if (this.hp <= 0) this.hp = 0;
        this.IsDeaded();

    }
    protected bool CheckDead()
    {
        return this.hp <= 0;
    }
    protected void IsDeaded()
    {
        if (!this.CheckDead()) return;
        this.isDead = true;
        this.OnDead();
    }
    protected virtual void OnDead()
    {

    }
}
