using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishController : MonoBehaviour
{
    public static bool caught;

    public float eatDistance;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    [Tooltip("The time it takes to turn around at max speed")]
    private float turnTime;
    [SerializeField]
    private float offTheHookDistance;

    private CharacterController characterController;
    private CameraController cameraController;
    private float actualAcceleration;

    [HideInInspector]
    public Vector3 currentForce;
    [HideInInspector]
    public Vector3 reelForce;
    [HideInInspector]
    public Vector3 caughtLineEntry;
    [HideInInspector]
    public float currentSpeed;

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

        characterController.Move(transform.forward * currentSpeed * Time.deltaTime);
        characterController.Move(currentForce * Time.deltaTime);
        characterController.Move(reelForce * Time.deltaTime);

        if (caught)
        {
            var baitItem = GetComponentInChildren<BaitItem>();
            baitItem.transform.position = transform.position + transform.forward;

            if (Vector3.Distance(transform.position, caughtLineEntry) > offTheHookDistance)
            {
                caught = false;
                reelForce = Vector3.zero;
                Destroy(baitItem.gameObject);
            }
        }
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
