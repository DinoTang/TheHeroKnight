using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlipDirect : EnemyAbstract
{
    // [Header("Enemy Flip Direct")]
    protected void FixedUpdate()
    {
        this.Flipping();
    }

    protected void Flipping()
    {
        this.FlipWithWayPoint();
        this.FlipWithPlayer();

    }
    protected void FlipWithWayPoint()
    {
        if (this.enemyCtrl.EnemyDetect.IsDetect) return;
        float direction = this.enemyCtrl.EnemyMovement.WayPoint.x - transform.parent.position.x;
        if (direction > 0 && transform.parent.localScale.x == -1)
            transform.parent.localScale = new Vector3(1, 1, 1);
        else if (direction < 0 && transform.parent.localScale.x == 1)
            transform.parent.localScale = new Vector3(-1, 1, 1);
    }
    protected void FlipWithPlayer()
    {
        if (!this.enemyCtrl.EnemyDetect.IsDetect) return;
        if (this.enemyCtrl.EnemyDetect.Diretion.x > 0 && transform.parent.localScale.x == -1)
            transform.parent.localScale = new Vector3(1, 1, 1);
        if (this.enemyCtrl.EnemyDetect.Diretion.x < 0 && transform.parent.localScale.x == 1)
            transform.parent.localScale = new Vector3(-1, 1, 1);
    }
}
