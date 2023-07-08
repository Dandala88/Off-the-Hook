using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishController : MonoBehaviour
{
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float maxYRotate;

    private CharacterController characterController;
    private Vector2 rotateInput;
    private float currentSpeed;
    private Vector2 currentRotation;
    private float actualAcceleration;

    bool swimming;
    bool braking;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        actualAcceleration = acceleration;
        if (braking) actualAcceleration = acceleration * 2;

        currentRotation.y += rotateInput.y;
        currentRotation.x += rotateInput.x;
        if(Mathf.Abs(currentRotation.y) > maxYRotate) currentRotation.y = maxYRotate * Mathf.Sign(currentRotation.y);

        transform.localRotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0f);
        currentSpeed = swimming ? currentSpeed + actualAcceleration * Time.deltaTime : currentSpeed - actualAcceleration * Time.deltaTime;

        if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
        if (currentSpeed < 0) currentSpeed = 0;

        characterController.Move(transform.forward * currentSpeed * Time.deltaTime);
    }

    public void Rotate(Vector2 rotateInput)
    {
        this.rotateInput = rotateInput;
    }

    public void Swim(bool activated)
    {
        swimming = activated;
    }

    public void Brake(bool activated)
    {
        braking = activated;
    }
}
