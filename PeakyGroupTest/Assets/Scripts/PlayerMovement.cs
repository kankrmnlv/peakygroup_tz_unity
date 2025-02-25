using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //movement
    public float moveSpeed;

    private CharacterController characterController;

    private float rotationSmoothing = .025f;

    private Vector2 move;

    //boundarie variables
    private float maxXpos, minXpos, maxZpos, minZpos;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        CalculateMovementBoundaries();
    }

    private void Update()
    {
        Vector3 movement = new Vector3 (move.x, 0f, move.y).normalized;

        if(movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSmoothing);
        }

        characterController.Move(movement * moveSpeed * Time.deltaTime);

        SetMovementBoundaries();
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
