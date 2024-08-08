using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : DinoBehaviourScript
{
    protected static InputManager instance;
    [SerializeField] protected float inputHorizontal;
    [SerializeField] protected float inputVertical;
    public static InputManager Instance => instance;
    public float InputHorizontal => inputHorizontal;
    public float InputVertical => inputVertical;
    protected override void Awake()
    {
        base.Awake();
        if (InputManager.instance != null) Debug.LogWarning("Only 1 InputManager allow exist");
        InputManager.instance = this;
    }
    protected void FixedUpdate()
    {
        this.GetInput();
    }

    protected void GetInput()
    {
        this.inputHorizontal = Input.GetAxis("Horizontal");
        this.inputVertical = Input.GetAxis("Vertical");
    }
}
