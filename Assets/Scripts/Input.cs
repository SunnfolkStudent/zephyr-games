using System;
using UnityEngine;

public class Input : MonoBehaviour
{
    private InputActions input;
    
    public Vector2 MoveInput { private set; get; }
    public bool JumpPressed { private set; get; }
    public bool JumpReleased { private set; get; }
    public bool JumpHeld { private set; get; }
    
    public bool DashSpressed { private set; get;}

    private void Update()
    {
        MoveInput = input.Player.Move.ReadValue<Vector2>();

        JumpPressed = input.Player.Jump.WasPressedThisFrame();
        JumpReleased = input.Player.Jump.WasReleasedThisFrame();
        JumpHeld = input.Player.Jump.ReadValue<float>() > 0;
        
        DashSpressed = input.Player.Dash.WasPressedThisFrame();
    }

    private void Awake() => input = new InputActions();

    private void OnEnable() => input.Enable();

    private void OnDisable() => input.Disable();
}