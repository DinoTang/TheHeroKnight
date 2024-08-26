using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : DinoBehaviourScript
{
    [SerializeField] protected int maxSlot = 10;
    [SerializeField] protected List<ItemInventory> items;
    protected override void Start()
    {
        this.PickupItem(ItemCode.Heath, 40);
        this.PickupItem(ItemCode.Arrow, 21);
    }

    public bool PickupItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int addMore;
        int newCount;

        for (int i = 0; i < maxSlot; i++)
        {
            ItemInventory itemExist = this.GetNonFullStack(itemCode);
            if (itemExist == null)
            {
                if (this.IsMaxSlot()) return false;
                itemExist = this.GetEmptyItem(itemProfile);
                this.items.Add(itemExist);
            }
            newCount = itemExist.itemCount + addRemain;

            if (newCount > itemExist.maxStack)
            {
                addMore = itemExist.maxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else addRemain -= newCount;

            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }
        return true;
    }
    protected ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO itemProfile in profiles)
        {
            if (itemProfile.itemCode != itemCode) continue;
            return itemProfile;
        }
        return null;
    }
    protected ItemInventory GetNonFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            if (this.IsFullStack(itemInventory)) continue;
            return itemInventory;
        }
        return null;
    }

    protected bool IsFullStack(ItemInventory itemInventory)
    {
        return itemInventory.itemCount >= itemInventory.maxStack;
    }

    protected ItemInventory GetEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack,
        };
        return itemInventory;
    }

    protected bool IsMaxSlot()
    {
        return this.items.Count >= maxSlot;
    }
}