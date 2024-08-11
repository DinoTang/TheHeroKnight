using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : DinoBehaviourScript
{
    [Header("Input Manager")]
    private int On = 0;
    protected static InputManager instance;
    public static InputManager Instance => instance;
    [SerializeField] protected float inputHorizontal;
    [SerializeField] protected float inputVertical;

    public float InputHorizontal => inputHorizontal;
    public float InputVertical => inputVertical;

    protected override void Awake()
    {
        base.Awake();
        if (InputManager.instance != null) Debug.LogWarning("Only 1 InputManager allow exist");
        InputManager.instance = this;
    }
    protected void Update()
    {
        this.GetInputAttack();
        this.GetInputMovement();
        this.GetInputChangeWeapon();
        this.GetInputDash();
    }

    protected void GetInputMovement()
    {
        this.inputHorizontal = Input.GetAxisRaw("Horizontal");
        this.inputVertical = Input.GetAxisRaw("Vertical");

    }
    [SerializeField] protected bool inputSwitchWeapon;
    [SerializeField] protected bool inputAttack;
    [SerializeField] protected bool inputDash = true;
    public bool InputSwitchWeapon => inputSwitchWeapon;
    public bool InputAttack => inputAttack;
    public bool InputDash => inputDash;
    public void SetAttack(bool _bool)
    {
        this.inputAttack = _bool;
    }
    public void SetDash(bool _bool)
    {
        this.inputDash = _bool;
    }
    protected void GetInputChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R) && this.On == 0)
        {
            this.inputSwitchWeapon = true;
            this.On = 1;
        }
        else if (Input.GetKeyDown(KeyCode.R) && this.On == 1)
        {
            this.inputSwitchWeapon = false;
            this.On = 0;
        }
    }
    protected void GetInputAttack()
    {
        if (Input.GetKeyDown(KeyCode.J)) this.inputAttack = true;
    }
    protected void GetInputDash()
    {
        if (Input.GetKeyDown(KeyCode.L)) this.inputDash = false;
    }
}
