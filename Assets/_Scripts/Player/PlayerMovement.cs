using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : DinoBehaviourScript
{
    [Header("Player Movement")]
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected int speed = 10;
    [SerializeField] protected float horizontal;
    [SerializeField] protected float vertical;
    [SerializeField] protected bool switchWeapon;
    [SerializeField] protected bool right;
    [SerializeField] protected bool left;
    [SerializeField] protected bool up;
    [SerializeField] protected bool down = true;
    public float Horizontal => horizontal;
    public float Vertical => vertical;
    public bool SwitchWeapon => switchWeapon;
    public bool Right => right;
    public bool Down => down;
    public bool Left => left;
    public bool Up => up;
    protected override void LoadComponent()
    {
        this.LoadRigidbody();
    }
    protected void LoadRigidbody()
    {
        if (this._rb != null) return;
        this._rb = GetComponentInParent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
    private void FixedUpdate()
    {
        this.Moving();
        this.SetDirect();
        this.ChangeWeapon();
    }
    protected void Moving()
    {
        this.horizontal = InputManager.Instance.InputHorizontal;
        this.vertical = InputManager.Instance.InputVertical;

        this.Move();

    }
    protected void Move()
    {
        this._rb.velocity = new Vector3(this.horizontal * this.speed, this.vertical * this.speed, 0f);
    }
    protected void SetDirect()
    {
        if (this.vertical < 0)
        {
            this.down = true;
            this.up = this.left = this.right = false;
        }
        if (this.horizontal > 0)
        {
            this.right = true;
            this.down = this.left = this.up = false;
        }
        if (this.horizontal < 0)
        {
            this.left = true;
            this.down = this.up = this.right = false;
        }
        if (this.vertical > 0)
        {
            this.up = true;
            this.down = this.left = this.right = false;
        }
    }
    protected bool ChangeWeapon()
    {
        this.switchWeapon = InputManager.Instance.InputSwitchWeapon;
        return this.switchWeapon;
    }
}
