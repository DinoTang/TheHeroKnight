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
    [SerializeField] protected bool inputSwitchWeapon;

    public float InputHorizontal => inputHorizontal;
    public float InputVertical => inputVertical;
    public bool InputSwitchWeapon => inputSwitchWeapon;
    protected override void Awake()
    {
        base.Awake();
        if (InputManager.instance != null) Debug.LogWarning("Only 1 InputManager allow exist");
        InputManager.instance = this;
    }
    protected void Update()
    {
        this.GetInputMovement();
        this.GetInputChangeWeapon();
    }

    protected void GetInputMovement()
    {
        this.inputHorizontal = Input.GetAxisRaw("Horizontal");
        this.inputVertical = Input.GetAxisRaw("Vertical");

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

}
