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

    private CharacterController characterController;
    private CameraController cameraController;
    private float currentSpeed;
    private float actualAcceleration;

    bool swimming;
    bool braking;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        actualAcceleration = acceleration;
        if (braking) actualAcceleration = acceleration * 2;

        currentSpeed = swimming ? currentSpeed + actualAcceleration * Time.deltaTime : currentSpeed - actualAcceleration * Time.deltaTime;

        if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
        if (currentSpeed < 0) currentSpeed = 0;

        if(currentSpeed > 0)
            transform.forward = cameraController.transform.forward;

        characterController.Move(transform.forward * currentSpeed * Time.deltaTime);
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
