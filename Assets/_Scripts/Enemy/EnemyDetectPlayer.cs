using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyDetectPlayer : EnemyAbstract
{
    [Header("Enemy Detect Player")]
    [SerializeField] protected CircleCollider2D collide;
    [SerializeField] protected Vector2 direction;
    [SerializeField] protected bool isDetect;
    public Vector2 Diretion => direction;
    public bool IsDetect => isDetect;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
    }
    protected void LoadCollider()
    {
        if (this.collide != null) return;
        this.collide = GetComponent<CircleCollider2D>();
        this.collide.isTrigger = true;
        this.collide.radius = 3;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.parent.gameObject.CompareTag("Player"))
        {
            this.direction = other.transform.parent.position - transform.parent.position;
            this.isDetect = true;
        }
    }
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.parent.gameObject.CompareTag("Player"))
        {
            this.isDetect = false;
        }
    }
}
