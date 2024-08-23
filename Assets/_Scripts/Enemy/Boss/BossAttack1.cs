using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack1 : DinoBehaviourScript
{
    [SerializeField] protected BossAttackCtrl bossAttackCtrl;
    [SerializeField] protected Transform player;
    [SerializeField] protected PolygonCollider2D collide;
    [SerializeField] protected float disToPlayer;
    [SerializeField] protected bool attack1;
    public Transform Player => player;
    public bool Attack1 => attack1;
    public bool isWorking1 = false;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
        this.LoadBossAttackCtrl();
        this.LoadCollider();
    }
    protected void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }
    protected void LoadBossAttackCtrl()
    {
        if (this.bossAttackCtrl != null) return;
        this.bossAttackCtrl = GetComponentInParent<BossAttackCtrl>();
        Debug.Log(transform.name + ": LoadBossAttackCtrl", gameObject);
    }
    protected void LoadCollider()
    {
        if (this.collide != null) return;
        this.collide = GetComponent<PolygonCollider2D>();
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected void Update()
    {
        if (this.bossAttackCtrl.BossCtrl.BossDamReceive.IsDead) return;
        if (this.bossAttackCtrl.BossCtrl.BossDamReceive.Hp <= 30) return;
        if (!isWorking1)
        {
            StartCoroutine(DoWork1());
        }
    }
    protected IEnumerator DoWork1()
    {
        this.isWorking1 = true;
        this.bossAttackCtrl.angry = true;


        yield return new WaitForSeconds(5);
        this.disToPlayer = this.bossAttackCtrl.DistanceToTarget(this.player.position);
        this.bossAttackCtrl.angry = false;
        this.bossAttackCtrl.isMoving = true;

        while (disToPlayer > 2)
        {
            this.disToPlayer = this.bossAttackCtrl.DistanceToTarget(this.player.position);
            this.bossAttackCtrl.BossCtrl.BossFlipDirect.Flipping(this.player);
            transform.parent.parent.position = this.bossAttackCtrl.MoveToTarget(this.player.position);
            yield return null;
        }
        this.bossAttackCtrl.isMoving = false;

        yield return new WaitForSeconds(0.2f);
        this.attack1 = true;
        this.collide.enabled = true;

        yield return new WaitForSeconds(0.2f);
        this.attack1 = false;
        this.collide.enabled = false;

        yield return new WaitForSeconds(1);
        this.isWorking1 = false;
        this.bossAttackCtrl.attackCount += 1;

        //Chuyển kĩ năng
        if (this.bossAttackCtrl.attackCount == 3)
        {
            this.isWorking1 = true;
            this.bossAttackCtrl.BossAttack2.isWorking2 = false;
        }

        if (this.bossAttackCtrl.BossCtrl.BossDamReceive.Hp <= 30)
            this.bossAttackCtrl.BossAttack2.isWorking2 = false;
    }
}
