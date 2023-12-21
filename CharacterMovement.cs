using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 5.0f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock the cursor to the game window and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X");

        // Rotate the character based on mouse movement
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // Get input for movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Move the character
        controller.Move(moveDirection * movementSpeed * Time.deltaTime);
    }
}

