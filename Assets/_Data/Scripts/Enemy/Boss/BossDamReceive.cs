using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamReceive : EnemyDamReceive
{
    protected override void SetPosDead()
    {

    }

    protected override void OnDead()
    {
        base.OnDead();
        AudioManager.Instance.StopMusic();

        // Dừng tất cả âm thanh boss
        AudioManager.Instance.StopMonsterRun();
        AudioManager.Instance.StopAxeSpinning();

        // Phát âm thanh chết
        AudioManager.Instance.PlaySFX("BossDeath");
    }
}
