using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : DinoBehaviourScript
{
    [Header("Damage Sender")]
    [SerializeField] protected int damage = 1;
    public int Damage => damage;

    protected void Send(Transform collider)
    {
        DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    protected void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
}
