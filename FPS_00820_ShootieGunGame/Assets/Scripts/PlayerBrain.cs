using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Redirection inputs to actions
/// </summary>
public class PlayerBrain : MonoBehaviour
{
    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.FPS.Jump.performed += Jump;
        controls.FPS.Move.performed += Move;
        controls.FPS.Look.performed += Look;
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        Debug.Log("Jumping!");
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        Vector2 inputValues = ctx.ReadValue<Vector2>();

        Debug.Log($"Moving {inputValues}");
    }
    
    private void Look(InputAction.CallbackContext ctx)
    {
        Vector2 inputValues = ctx.ReadValue<Vector2>();

        Debug.Log($"Looking {inputValues}");
    }
}
