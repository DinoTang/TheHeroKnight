using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : DinoBehaviourScript
{
    [SerializeField] protected Rigidbody _rb;
    [SerializeField] protected int speed = 10;
    protected override void LoadComponent()
    {
        this.LoadRigidbody();
    }
    protected void LoadRigidbody()
    {
        if (this._rb != null) return;
        this._rb = GetComponentInParent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
    private void FixedUpdate()
    {
        this.Moving();
    }
    protected void Moving()
    {
        float horizontal = InputManager.Instance.InputHorizontal;
        float vertical = InputManager.Instance.InputVertical;
        this._rb.velocity = new Vector3(this.speed * horizontal, this.speed * vertical, 0f);
    }
}
