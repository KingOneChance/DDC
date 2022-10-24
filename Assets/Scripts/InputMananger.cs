using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMananger : MonoBehaviour
{
    [field: Header("Movement Keyboard Input")]
    [field: SerializeField] public float Horizontal { get; private set; } = 0f;
    [field: SerializeField] public float Vertical { get; private set; } = 0f;
    [field: SerializeField] public bool HasHorizontalInput { get; private set; } = false;
    [field: SerializeField] public bool HasVerticalInput { get; private set; } = false;

    [field: Header("Mouse Input")]
    [field: SerializeField] public bool LeftClicking { get; private set; } = false;
    [field: SerializeField] public bool LeftClickUp { get; private set; } = false;
    [field: SerializeField] public bool LeftClickDown { get; private set; } = false;
    [field: SerializeField] public bool RightClicking { get; private set; } = false;
    [field: SerializeField] public bool RightClickUp { get; private set; } = false;
    [field: SerializeField] public bool RightClickDown { get; private set; } = false;
    [field: SerializeField] public bool ScrollWheelInput { get; private set; } = false;

    [field: Header("Anything Else Keyboard Input")]
    [field: SerializeField] public bool Rkey { get; private set; } = false;
    [field: SerializeField] public bool RkeyUp { get; private set; } = false;
    [field: SerializeField] public bool RkeyDown { get; private set; } = false;
    private void Update()
    {
        UpdateMovementInput();
        UpdateMouseInput();
        UpdateOtherKeyboardInput();
    }
    private void UpdateMovementInput() // Update WASD Input
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        HasHorizontalInput = !Mathf.Approximately(Horizontal, 0f);
        HasVerticalInput = !Mathf.Approximately(Vertical, 0f);
    }
    private void UpdateMouseInput() // Update left, right mouse button input and scroll wheel input
    {
        LeftClicking = Input.GetMouseButton(0);
        LeftClickUp = Input.GetMouseButtonUp(0);
        LeftClickDown = Input.GetMouseButtonDown(0);

        RightClicking = Input.GetMouseButton(1);
        RightClickUp = Input.GetMouseButtonUp(1);
        RightClickDown = Input.GetMouseButtonDown(1);

     //   ScrollWheelInput = !Mathf.Approximately(Input.GetAxis("Mouse Scroll Wheel"), 0f);
    }
    private void UpdateOtherKeyboardInput() // Update other key input
    {
        // R Key
        Rkey = Input.GetKey(KeyCode.R);
        RkeyUp = Input.GetKeyUp(KeyCode.R);
        RkeyDown = Input.GetKeyDown(KeyCode.R);
    }
}