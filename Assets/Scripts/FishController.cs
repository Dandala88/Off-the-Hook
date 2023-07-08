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

    bool swimming;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {       
        currentRotation.y += rotateInput.y;
        currentRotation.x += rotateInput.x;
        Debug.Log(currentRotation.y);
        if(Mathf.Abs(currentRotation.y) > maxYRotate) currentRotation.y = maxYRotate * Mathf.Sign(currentRotation.y);
        transform.localRotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0f);
        currentSpeed = swimming ? currentSpeed + acceleration * Time.deltaTime : currentSpeed - acceleration * Time.deltaTime;

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
}
