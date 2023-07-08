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
    [Tooltip("The time it takes to turn around at max speed")]
    private float turnTime;

    private CharacterController characterController;
    private CameraController cameraController;
    public float currentSpeed;
    private float actualAcceleration;
    public Vector3 currentForce;

    bool swimming;
    bool braking;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    Vector3 v = Vector3.zero;
    private void Update()
    {
        actualAcceleration = acceleration;
        if (braking) actualAcceleration = acceleration * 2;

        currentSpeed = swimming ? currentSpeed + actualAcceleration * Time.deltaTime : currentSpeed - actualAcceleration * Time.deltaTime;

    if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
    if (currentSpeed < 0) currentSpeed = 0;

        if (currentSpeed > 0)
        {
            var relativeTurn = turnTime * (currentSpeed / maxSpeed);
            transform.forward = Vector3.SmoothDamp(transform.forward, cameraController.transform.forward, ref v, relativeTurn);
        }

        characterController.Move((transform.forward + currentForce) * currentSpeed * Time.deltaTime);
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
