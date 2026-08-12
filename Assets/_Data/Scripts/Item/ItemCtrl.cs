using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : BaseBehavior
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemDespawn();
    }
    protected void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": LoadItemDespawn", gameObject);
    }
}
