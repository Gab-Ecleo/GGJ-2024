using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float moveSpeed;

    private Rigidbody rb;
    private Vector3 playerRotation;
    private Vector3 horizontalInput;
    private Vector3 verticalInput;
    private Vector3 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdateInput();
    }

    private void FixedUpdate()
    {
        RotatePlayer();
        MovePlayer();
    }

    private void UpdateInput()
    {
        playerRotation.y = Input.GetAxis("Mouse X") * mouseSensitivity;

        horizontalInput = transform.right * Input.GetAxisRaw("Horizontal");
        verticalInput = transform.forward * Input.GetAxisRaw("Vertical");
        moveInput = horizontalInput + verticalInput;
    }

    private void RotatePlayer()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(playerRotation));
    }

    private void MovePlayer()
    {
        moveInput = moveInput.normalized * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(transform.position + moveInput);
    }
}
