using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    public Action<Vector3> OnMovementDirectionInput { get; set; }
    public Action<Vector2> OnMovementInput { get; set; }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        GetMovementInput();
        GetMovementDirection();
    }

    private void GetMovementDirection()
    {
        Vector3 cameraForewardDirection = Camera.main.transform.forward;
        Debug.DrawRay(Camera.main.transform.position, cameraForewardDirection * 5, Color.red);
        Vector3 directionToMoveIn = Vector3.Scale(cameraForewardDirection, (Vector3.right + Vector3.forward));
        Debug.DrawRay(Camera.main.transform.position, directionToMoveIn * 5, Color.blue);
        OnMovementDirectionInput?.Invoke(directionToMoveIn.normalized);
    }

    private void GetMovementInput()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnMovementInput?.Invoke(input);
    }
}
