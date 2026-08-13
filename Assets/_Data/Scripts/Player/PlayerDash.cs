using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TrailRenderer))]
public class PlayerDash : PlayerAbstract
{
    [Header("Dashing")]
    [SerializeField] protected TrailRenderer trailRenderer;
    [SerializeField] protected bool canDash = true;
    [SerializeField] protected bool dash = true;
    [SerializeField] protected bool isDashing;
    [SerializeField] protected float dashingPower = 12f;
    [SerializeField] protected float dashingTime = 0.2f;
    [SerializeField] protected float dashingCooldown = 0.7f;

    protected float cooldownTimer = 0f;

    public bool IsDashing => isDashing;
    public float CooldownTimer => cooldownTimer;
    public float DashingCooldown => dashingCooldown;
    protected void FixedUpdate()
    {
        this.GetInput();
        this.Dashing();
        this.UpdateCooldown();
    }

    protected void UpdateCooldown()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTrailRenderer();
    }
    protected void LoadTrailRenderer()
    {
        if (this.trailRenderer != null) return;
        this.trailRenderer = GetComponent<TrailRenderer>();
        Debug.Log(transform.name + ": LoadTrailRenderer", gameObject);
    }
    protected void GetInput()
    {
        if (this.playerCtrl.PlayerDamReceive.IsDead) return;
        this.dash = InputManager.Instance.InputDash;
    }
    protected void Dashing()
    {
        if (!this.dash && this.canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        this.canDash = false;
        this.isDashing = true;

        Vector2 dashDirection =
        new Vector2(this.playerCtrl.PlayerMovement.Horizontal, this.playerCtrl.PlayerMovement.Vertical).normalized;
        this.playerCtrl.PlayerMovement._Rb.linearVelocity = dashDirection * dashingPower;
        this.trailRenderer.emitting = true;
        AudioManager.Instance.PlaySFX("Dash");

        yield return new WaitForSeconds(dashingTime);
        this.trailRenderer.emitting = false;
        this.isDashing = false;

        this.cooldownTimer = dashingCooldown;

        yield return new WaitForSeconds(dashingCooldown);
        this.dash = true;
        this.canDash = true;
        InputManager.Instance.SetDash(true);
    }
}
