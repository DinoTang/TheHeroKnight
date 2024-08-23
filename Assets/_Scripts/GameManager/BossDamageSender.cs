using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageSender : DamageSender
{
    // [Header("Boss Damage Sender")]
    // [SerializeField] protected int damage = 1;
    // public int Damage => damage;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) return;
        this.SendToTransform(other.transform);
    }
}
