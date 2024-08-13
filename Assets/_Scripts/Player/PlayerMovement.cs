using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
public class PlayerMovement : PlayerAbstract
{
    [Header("Player Movement")]
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected int speed = 5;
    [SerializeField] protected float horizontal;
    [SerializeField] protected float vertical;
    [SerializeField] protected bool switchWeapon;
    public Rigidbody2D _Rb => _rb;
    public float Horizontal => horizontal;
    public float Vertical => vertical;
    public bool SwitchWeapon => switchWeapon;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
    }
    private void FixedUpdate()
    {
        this.GetInput();
        this.Moving();
        this.ChangeWeapon();
    }
    protected void LoadRigidbody()
    {
        if (this._rb != null) return;
        this._rb = GetComponentInParent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
    protected void GetInput()
    {
        this.horizontal = InputManager.Instance.InputHorizontal;
        this.vertical = InputManager.Instance.InputVertical;
    }
    protected void Moving()
    {
        if (this.playerCtrl.PlayerDash.IsDashing) return;
        this._rb.velocity = new Vector3(this.horizontal * this.speed, this.vertical * this.speed, 0f);
    }
    protected void ChangeWeapon()
    {
        if (this.TerminateCondition()) return;
        this.switchWeapon = InputManager.Instance.InputSwitchWeapon;
    }
    public bool TerminateCondition()
    {
        if (!this.playerCtrl.PlayerAttack.Attack && !this.playerCtrl.PlayerShooting.Shoot) return false;
        return true;
    }
}
