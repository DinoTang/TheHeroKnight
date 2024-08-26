using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : Spawner
{
    [Header("Enemy Spawn")]
    protected static EnemySpawn instance;
    public static EnemySpawn Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawn.instance != null) Debug.LogWarning("Only 1 EnemySpawn exist allow");
        EnemySpawn.instance = this;
    }
}
