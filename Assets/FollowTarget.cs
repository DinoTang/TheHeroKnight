using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : DinoBehaviourScript
{
    [SerializeField] protected Camera cam;
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed;
    [SerializeField] protected Vector2 minXY;
    [SerializeField] protected Vector2 maxXY;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
        this.LoadTarget();
    }
    protected void FixedUpdate()
    {
        this.Following();
    }
    protected void LoadCamera()
    {
        if (this.cam != null) return;
        this.cam = FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }
    protected void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }
    protected void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, this.minXY.x, this.maxXY.x);
        newPos.y = Mathf.Clamp(newPos.y, this.minXY.y, this.maxXY.y);
        transform.position = newPos;
    }
}
