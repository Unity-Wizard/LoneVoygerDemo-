using System;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpForce = 5.0f;
    private float verticalVelocity = 0.0f;

    private CharacterController characterController;
    private PlayerUIHandler UIhandler;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Player movement
        float moveDirectionX = Input.GetAxis("Horizontal") * speed;
        float moveDirectionZ = Input.GetAxis("Vertical") * speed;

        Vector3 move = transform.right * moveDirectionX + transform.forward * moveDirectionZ;

        // Gravity and jumping
        if (characterController.isGrounded)
        {
            verticalVelocity = -0.5f; // Small value to keep the character grounded
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        move.y = verticalVelocity;
        characterController.Move(move * Time.deltaTime);

        // Player looking around
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);
        //camera movement here
        Camera camera = GetComponentInChildren<Camera>();
        float newRotationX = camera.transform.localEulerAngles.x - mouseY;
        if (newRotationX > 180) newRotationX -= 360;
        newRotationX = Mathf.Clamp(newRotationX, -90, 90);
        camera.transform.localEulerAngles = new Vector3(newRotationX, 0, 0);
    }
}