using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDespawn : DespawnByDistance
{
    protected override void DespawnObj()
    {
        ArrowSpawn.Instance.Despawn(transform.parent);
    }
}
