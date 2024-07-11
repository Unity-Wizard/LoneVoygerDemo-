using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPcontroller : MonoBehaviour
{
    public Transform cameraTransform;
    public Texture2D crosshair;
    private CharacterController characterController;

    public float speed = 6f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        // Input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Check if there's any input
        if (direction.magnitude >= 0.1f)
        {
            // Determine the target angle based on camera's facing direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            // Rotate the character
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Move the character
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}