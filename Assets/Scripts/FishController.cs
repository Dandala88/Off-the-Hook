using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    [Tooltip("Higher the number the more sensitive")]
    [Min(0.01f)]
    private float rotationSensitivity;

    private CharacterController characterController;
    private Vector2 input;
    private Vector3 movement;
    private float currentSpeed;

    bool swimming;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        transform.Rotate(input.y * rotationSensitivity, input.x * rotationSensitivity, 0f);
        currentSpeed = swimming ? currentSpeed + acceleration * Time.deltaTime : currentSpeed - acceleration * Time.deltaTime;

        if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
        if (currentSpeed < 0) currentSpeed = 0;

        characterController.Move(transform.forward * currentSpeed * Time.deltaTime);
    }

    public void Move(Vector2 input)
    {
        this.input = input;
    }

    public void Swim(bool activated)
    {
        swimming = activated;
    }
}
