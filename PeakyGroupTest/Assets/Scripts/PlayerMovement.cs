using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement
    public float moveSpeed;

    private CharacterController characterController;

    private float rotationSmoothing = .05f;

    private float horizontalInput;
    private float verticalInput;

    //boundarie variables
    private float maxXpos, minXpos, maxZpos, minZpos;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        CalculateMovementBoundaries();
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

        SetMovementBoundaries();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void SetMovementBoundaries()
    {
        //Sets movement boundaries
        float clampedX = Mathf.Clamp(transform.position.x, minXpos, maxXpos);
        float clampedZ = Mathf.Clamp(transform.position.z, minZpos, maxZpos);

        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }

    private void CalculateMovementBoundaries()
    {
        //Calculates the ground size
        Vector3 groundSize = GameObject.FindWithTag("Ground").GetComponent<Renderer>().bounds.size;

        maxXpos = groundSize.x / 2f;
        minXpos = -groundSize.x / 2f;
        maxZpos = groundSize.z / 2f;
        minZpos = -groundSize.z / 2f;
    }
}
