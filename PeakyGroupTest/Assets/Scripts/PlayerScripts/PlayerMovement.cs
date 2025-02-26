using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedMultiplier = 1f;

    private CharacterController characterController;

    private float turnSpeed = 7f;

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
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movement), turnSpeed * Time.deltaTime * 100f);
        }

        characterController.Move(movement * (moveSpeed * speedMultiplier) * Time.deltaTime);

        SetMovementBoundaries();
    }

    public void ApplySpeedBoost(float boostMultiplier, float duration)
    {
        StartCoroutine(SpeedBoost(boostMultiplier, duration));
    }
    private IEnumerator SpeedBoost(float boostMultiplier, float duration)
    {
        speedMultiplier = boostMultiplier;
        Color startColor = gameObject.GetComponent<Renderer>().material.color;
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(duration);
        speedMultiplier = 1f;
        gameObject.GetComponent<Renderer>().material.color = startColor;
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
