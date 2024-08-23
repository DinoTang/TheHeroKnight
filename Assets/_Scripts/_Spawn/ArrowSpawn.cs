using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : Spawner
{
    [Header("Arrow Spawn")]
    protected static ArrowSpawn instance;
    public static ArrowSpawn Instance => instance;
    protected static string arrowOne = "Arrow_1";
    protected static string arrowTwo = "Arrow_2";
    public string ArrowOne => arrowOne;
    public string ArrowTwo => arrowTwo;
    protected override void Awake()
    {
        base.Awake();
        if (ArrowSpawn.instance != null) Debug.LogWarning("Only 1 ArrowSpawn exist allow");
        ArrowSpawn.instance = this;
    }
}
