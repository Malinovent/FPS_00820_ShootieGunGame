using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Redirection inputs to actions
/// </summary>
public class PlayerBrain : MonoBehaviour
{
    [SerializeField] PlayerMotor playerMotor;
    [SerializeField] PlayerCamera playerCamera;

    PlayerControls controls;

    Vector2 moveInput;
    bool isActive = true;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.FPS.Jump.performed += Jump;

        controls.FPS.Move.performed += Move;
        controls.FPS.Move.canceled += Move;

        controls.FPS.Look.performed += Look;
    }

    private void Update()
    {
        if (!isActive)
            return;

        playerMotor.Move(moveInput);
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }


    private void Jump(InputAction.CallbackContext ctx)
    {
        Debug.Log("Jumping!");
    }

    private void Look(InputAction.CallbackContext ctx)
    {
        Vector2 inputValues = ctx.ReadValue<Vector2>();

        //Rotate player around the y axis
        playerMotor.Rotate(inputValues.x);

        //Roate the camera aroudn the x axis
        playerCamera.Rotate(inputValues.y);
    }
}
