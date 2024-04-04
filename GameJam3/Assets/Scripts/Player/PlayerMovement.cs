using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public float rotationSpeed, movementSpeed, gravity = 20;
    Vector3 movementVector = Vector3.zero;
    private float desiredRotationAngle = 0;
    Animator animator;

    private void Start() {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (controller.isGrounded && movementVector.magnitude > 0) {
            float animationSpeedMultiplier = SetAnimation();
            RotatePlayer();
            movementVector *= animationSpeedMultiplier;
        }
        movementVector.y -= gravity;
        controller.Move(movementVector * Time.deltaTime);
    }

    public void HandleMovement(Vector2 input) {
        if (controller.isGrounded) {
            if (input.y > 0) {
                movementVector = transform.forward * movementSpeed;
            } else {
                movementVector = Vector3.zero;
                animator.SetFloat("Move", 0);
            }
        }
    }

    public void HandleMovementDirection(Vector3 direction) {
        int sign = Vector3.Cross(transform.forward, direction).y < 0 ? -1 : 1;
        desiredRotationAngle = Vector3.Angle(transform.forward, direction) * sign;    
    }

    public bool IsAbleToRotate() {
        return desiredRotationAngle > 10 || desiredRotationAngle < -10;
    }

    private void RotatePlayer() {
        if(IsAbleToRotate()) {
            transform.Rotate(Vector3.up * desiredRotationAngle * rotationSpeed * Time.deltaTime);
         }
    }

    private float SetAnimation() {
        float currentAnimationSpeed = animator.GetFloat("Move");
        Debug.Log(desiredRotationAngle);
        if (IsAbleToRotate()) {
            if (currentAnimationSpeed < 0.2f) {
                currentAnimationSpeed += Time.deltaTime * 2;
                currentAnimationSpeed = Mathf.Clamp(currentAnimationSpeed, 0, 0.2f);
            }
        } else {
            if (currentAnimationSpeed < 1f) {
                currentAnimationSpeed += Time.deltaTime * 2;                
            } else {
                currentAnimationSpeed = 1f;
            }
        }

        animator.SetFloat("Move", currentAnimationSpeed);

        return currentAnimationSpeed;
    }
}
