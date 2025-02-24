using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private CharacterController characterController;

    private float rotationSmoothing = .05f;

    private float horizontalInput;
    private float verticalInput;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GetInput();

        Vector3 movement = new Vector3 (horizontalInput, 0f, verticalInput).normalized;

        if(movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSmoothing);
        }

        characterController.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
}
