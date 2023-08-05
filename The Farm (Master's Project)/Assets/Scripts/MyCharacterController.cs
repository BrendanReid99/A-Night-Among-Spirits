using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 100f;
    public float damping = 6f; // Adjust this value to control the damping strength
    public float gravity = 9.81f;

    private float verticalRotation = 0f;
    private CharacterController characterController;
    private Vector3 playerVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Player Look (Mouse)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        // Player Movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Get the forward direction of the camera
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f; // Make sure it's a horizontal direction (no vertical component)

        // Get the right direction of the camera
        Vector3 cameraRight = Camera.main.transform.right;
        cameraRight.y = 0f; // Make sure it's a horizontal direction (no vertical component)

        // Calculate the movement direction based on camera orientation
        Vector3 moveDirection = cameraForward.normalized * verticalMovement + cameraRight.normalized * horizontalMovement;
        moveDirection = moveDirection.normalized;

        // Apply movement to the character controller
        characterController.Move(moveDirection * movementSpeed * Time.fixedDeltaTime);

        ApplyGravity();
    }

    void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            // Apply gravity to the player velocity
            playerVelocity.y -= gravity * Time.fixedDeltaTime;

            // Apply the velocity to the character controller
            characterController.Move(playerVelocity * Time.fixedDeltaTime);
        }
        else
        {
            // Reset the vertical velocity when grounded
            playerVelocity.y = 0f;
        }
    }

}
