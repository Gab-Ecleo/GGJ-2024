using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Range (1,15)] [SerializeField] private float nodLimit;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float moveSpeed;

    private Rigidbody rb;
    private Vector3 playerRotation;
    private Vector3 horizontalInput;
    private Vector3 verticalInput;
    private Vector3 moveInput;
    private float headNod;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (PauseState.isPaused) return;
        UpdateInput();
    }

    private void FixedUpdate()
    {
        if (PauseState.isPaused) return;
        RotatePlayer();
        MovePlayer();
        HeadMovement();
    }

    private void UpdateInput()
    {
        playerRotation.y = Input.GetAxis("Mouse X") * mouseSensitivity;

        horizontalInput = transform.right * Input.GetAxisRaw("Horizontal");
        verticalInput = transform.forward * Input.GetAxisRaw("Vertical");

        if (Input.GetAxisRaw("Horizontal") != 0) EventManager.ON_WALK?.Invoke();
        if (Input.GetAxisRaw("Vertical") != 0) EventManager.ON_WALK?.Invoke();

        moveInput = horizontalInput + verticalInput;
    }

    private void RotatePlayer()
    {
        rb.angularVelocity = Vector3.zero;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(playerRotation));
    }

    private void MovePlayer()
    {
        moveInput = moveInput.normalized * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(transform.position + moveInput);
    }

    private void HeadMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector2 mouseOrientation = new Vector2(mouseX, mouseY);

        headNod -= mouseOrientation.y * mouseSensitivity;
        headNod = Mathf.Clamp(headNod, -nodLimit, nodLimit);

        Camera.main.transform.localEulerAngles = Vector3.right * headNod;
        transform.Rotate(Vector3.up * mouseOrientation.x * mouseSensitivity);
    }
}
